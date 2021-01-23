    using System;
    using System.Net;
    using System.Windows;
    using Microsoft.Phone.Controls;
    using Newtonsoft.Json;
    
    namespace PhoneApp2
    {
        public static class Extensions
        {
    
            public static string GetHtmlDecoded(this string str)
            {
                return HttpUtility.HtmlDecode(str);
            }
    
            public static string GetHtmlEncoded(this string str)
            {
                return HttpUtility.HtmlEncode(str);
            }
    
        }
    
        public partial class MainPage : PhoneApplicationPage
        {
            // Constructor
            public MainPage()
            {
                InitializeComponent();
            }
    
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
    
    
                var arrStr = new[,]
                    {
                        {"aaaa$ffeaw&fewa=324&fewa", "fewa"},
                        {"aafw&fewa=324&fewa", "fefewa"},
                    };
    
    
                string param = JsonConvert.SerializeObject(arrStr);
                param = Uri.EscapeDataString( param);
    
                var destination = new Uri("/Page1.xaml?arr=" + param, UriKind.Relative);
                NavigationService.Navigate(destination );
            }
        }
    }
