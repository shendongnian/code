    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Documents;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using BibleApps.Common;
    using BibleApps.DataModel; 
    
    namespace BibleApps
    {
        public class FormattedTextBehavior : DependencyObject
        {
            public static string GetFormattedText(DependencyObject obj)
            {
                return (string)obj.GetValue(FormattedTextProperty);
            }
    
            public static void SetFormattedText(DependencyObject obj, string value)
            {
                obj.SetValue(FormattedTextProperty, value);
            }
    
            public static readonly DependencyProperty FormattedTextProperty =
                DependencyProperty.RegisterAttached("FormattedText",
                                                    typeof(string),
                                                    typeof(FormattedTextBehavior),
                                                    new PropertyMetadata("", FormattedTextChanged));
    
            private static void FormattedTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                TextBlock textBlock = sender as TextBlock;
                string value = e.NewValue as string;
                string[] tokens = value.Split(' ');
                string[] querytokens = SuspensionManager.SessionState["query"].ToString().Split(' ');
                foreach (string token in tokens)
                {
                    Run kata = new Run();
                    bool ketemu = false;
                    foreach (string querytoken in querytokens)
                    {
                        if (token.ToLower().Contains(querytoken.ToLower())) {
                            ketemu = true;
                            break;
                        }
                    }
                    if (ketemu){
                        kata.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 80));
                        kata.FontWeight = Windows.UI.Text.FontWeights.Bold;
                        kata.Text = token + " ";
                        textBlock.Inlines.Add(kata);
                    }
                    else {
                        kata.Text = token + " ";
                        textBlock.Inlines.Add(kata);
                    }
                }
            }
        }
    }
