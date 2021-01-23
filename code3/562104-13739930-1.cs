    using System;
    using System.Windows;
    using Awesomium.Windows.Controls;
    using Awesomium.Core;
    
    namespace utilities
    {
        
        public class WebBrowserHelper {
            
            public static readonly DependencyProperty BodyProperty =
                DependencyProperty.RegisterAttached("Body", typeof (string), typeof(WebBrowserHelper), new PropertyMetadata(OnBodyChanged));
        
            public static string GetBody(DependencyObject dependencyObject) {
                return (string) dependencyObject.GetValue(BodyProperty);
            }
        
            public static void SetBody(DependencyObject dependencyObject, string body) {
                dependencyObject.SetValue(BodyProperty, body);
            }
        
            private static void ScrollDataReceivedDelegate(object sender, ScrollDataEventArgs e)
            {
                var webControl = (Awesomium.Windows.Controls.WebControl) sender;
                webControl.Height = e.ScrollData.ContentHeight;
                webControl.Width = e.ScrollData.ContentWidth;
                webControl.Visibility = Visibility.Visible;
            }
            
            private static void OnBodyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
                var webControl = (Awesomium.Windows.Controls.WebControl) d;
                webControl.LoadHTML((string)e.NewValue);
                webControl.ScrollDataReceived += new ScrollDataReceivedEventHandler(ScrollDataReceivedDelegate);
                webControl.LoadCompleted += delegate {
                    webControl.RequestScrollData();
                };
            }
        }
    }
