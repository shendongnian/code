    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace so.Localization
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        [ValueConversion( typeof( string ), typeof( string ) )]
        public class TranslateConverter : IValueConverter
        {
            #region Implementation of IValueConverter
    
            public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
            {
                // if using binding
                if( value != null && value is string )
                {
                    return ( (string)value ).TranslateBinding();
                }
    
                // if using a general paramater
                if( parameter != null && parameter is string )
                {
                    return ( (string)parameter ).TranslateParameter();
                }
    
                return DependencyProperty.UnsetValue;
            }
    
            public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    
        public static class Ext
        {
            public static string TranslateBinding( this string input )
            {
                // translat to whatever...
                return input + " (translated binding)";
            }
    
            public static string TranslateParameter( this string input )
            {
                // translat to whatever...
                return input + " (translated parameter)";
            }
        }
    }
