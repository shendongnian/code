    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    namespace DPTest
    {
        public sealed partial class UserControl1 : UserControl
        {
            public static readonly DependencyProperty TheCountProperty =
                DependencyProperty.Register(
                    "TheCount",
                    typeof(int),
                    typeof(UserControl1),
                    new PropertyMetadata(
                        0,
                        new PropertyChangedCallback(TheCountProperty_Changed)));
            public int TheCount
            {
                get { return (int)GetValue(TheCountProperty); }
                set { SetValue(TheCountProperty, value); }
            }
            private static void TheCountProperty_Changed(DependencyObject source, DependencyPropertyChangedEventArgs e)
            {
            }
            public UserControl1()
            {
                this.InitializeComponent();
            }
            private void btnLess_Click(object sender, RoutedEventArgs e)
            {
                //lblCount.Text = (Convert.ToInt32(lblCount.Text) - 1).ToString();
                this.Dispatcher.InvokeAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Low,
                    (s, a) => this.TheCount -= 1,
                    this,
                    null);
            }
            private void btnMore_Click(object sender, RoutedEventArgs e)
            {
                //lblCount.Text = (Convert.ToInt32(lblCount.Text) + 1).ToString();
                this.Dispatcher.InvokeAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Low,
                    (s, a) => this.TheCount += 1,
                    this,
                    null);
            }
        }
        public class IntToStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                return value.ToString();
            }
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
    }
