using proect_2.Core;
using Proect_2_gif.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proect_2_gif.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainLoginPage.xaml
    /// </summary>
    public partial class MainLoginPage : Page
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) ||
                string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Oшибка ввода данных",
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    User userModel = CoreConnection.DB.Users.FirstOrDefault(u => u.UserLogin == TbLogin.Text && u.UserPassword == PbPassword.Password);
                    if (userModel != null)
                    {
                        MessageBox.Show($"{userModel.UserLogin} - выполнил успешный вход!",
                                        "Системное Сообщение",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Oшибка ввода данных",
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                }
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new RegistrationPage());
        }
    }
}
