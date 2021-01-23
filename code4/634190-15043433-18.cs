    using Windows.UI.ApplicationSettings;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls.Primitives;
    namespace CSharp_Settings.Settings
    {
        public sealed partial class Help_Settings 
        {
            public Help_Settings()
            {
                InitializeComponent();
            }
     
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                if (Parent is Popup)
                    ((Popup)Parent).IsOpen = false;
                SettingsPane.Show();
            }
        }
    }
