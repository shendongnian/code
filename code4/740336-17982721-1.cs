    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    
    namespace Grub2._0
    {
        public partial class Time2 : PhoneApplicationPage
        {
            public Time2()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (AMRadioButton.IsChecked == true)
                    NavigationService.Navigate(new Uri("/PolicemanFood.xaml", UriKind.Relative));
                else if (PMRadioButton.IsChecked == false)
                    NavigationService.Navigate(new Uri("/Weed.xaml", UriKind.Relative));
                else
                    NavigationService.Navigate(new Uri("/BurgerKing.xaml", UriKind.Relative));
            }
        }
    }
