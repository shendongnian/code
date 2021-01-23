    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace test
    {
    
        public class RGBtoBrushConverter : MarkupExtension, IMultiValueConverter
        {
            static RGBtoBrushConverter converter;
            public RGBtoBrushConverter() { }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (converter == null) converter = new RGBtoBrushConverter();
                return converter;
            }
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    byte R = System.Convert.ToByte(values[0]);
                    byte G = System.Convert.ToByte(values[1]);
                    byte B = System.Convert.ToByte(values[2]);
                    return new System.Windows.Media.SolidColorBrush(Color.FromArgb(byte.MaxValue, R, G, B));
                }
                catch { return Brushes.Purple; }
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        public partial class MainWindow : Window
        {
            public int R
            {
                get { return (int)GetValue(RProperty); }
                set { SetValue(RProperty, value); }
            }
            public static readonly DependencyProperty RProperty = DependencyProperty.Register("R", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
    
            public int G
            {
                get { return (int)GetValue(GProperty); }
                set { SetValue(GProperty, value); }
            }
            public static readonly DependencyProperty GProperty = DependencyProperty.Register("G", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
            public int B
            {
                get { return (int)GetValue(BProperty); }
                set { SetValue(BProperty, value); }
            }
            public static readonly DependencyProperty BProperty = DependencyProperty.Register("B", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
    
    
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }
