    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Navigation;
    
    namespace WpfWbApp
    {
        //
        // By Noseratio [http://stackoverflow.com/users/1768303/noseratio]
        //
        // Question: http://stackoverflow.com/questions/17170011/c-sharp-webbrowser-panningmode
        //
        
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                SetBrowserCompatibilityMode();
                InitializeComponent();
                this.Loaded += MainWindow_Loaded;
                this.WB.LoadCompleted += WB_LoadCompleted;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                this.WB.Navigate(new Uri(new Uri(Assembly.GetExecutingAssembly().CodeBase), "content/test.htm").AbsoluteUri);
            }
    
            void WB_LoadCompleted(object sender, NavigationEventArgs e)
            {
                this.WB.Focus();
                this.WB.InvokeScript("focus");
            }
    
            private void SetBrowserCompatibilityMode()
            {
                // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
                
                // FeatureControl settings are per-process
                var fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
                if (String.Compare(fileName, "devenv.exe", true) == 0) // make sure we're not running inside Visual Studio
                    return;
    
                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
                    UInt32 mode = 10000; // 10000; 
                    key.SetValue(fileName, mode, RegistryValueKind.DWord);
                }
    
                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BLOCK_LMZ_SCRIPT",
                    RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    // enable <scripts> in local machine zone
                    UInt32 mode = 0;
                    key.SetValue(fileName, mode, RegistryValueKind.DWord);
                }
    
                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_NINPUT_LEGACYMODE",
                    RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    // disable Legacy Input Model
                    UInt32 mode = 0;
                    key.SetValue(fileName, mode, RegistryValueKind.DWord);
                }
    
            }
    
        }
    }
