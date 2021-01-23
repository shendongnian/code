    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Win32;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Page1.xaml
        /// </summary>
        public partial class Page1 : Page
        {
            private RegistryKey regKeyCurrentUser;
            private RegistryKey regSubKeyCurrent;
            
            public Page1()
            {
                InitializeComponent();
            }
            
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var page2 = new Page2();
                this.NavigationService.Navigate(page2);
            }
    
            private void Page1_OnLoaded(object sender, RoutedEventArgs e)
            {
                regKeyCurrentUser = Registry.CurrentUser;
                regSubKeyCurrent = regKeyCurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current", true);
                regSubKeyCurrent.SetValue("", "");
            }
    
            private void Page_Unloaded(object sender, RoutedEventArgs e)
            {
                var regSubKeyDefault = regKeyCurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Default");
                regSubKeyCurrent.SetValue("", regSubKeyDefault.GetValue("",""));
            }
        }
    }
