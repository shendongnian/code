     public class ColorValueConverter : MarkupExtension, IValueConverter
        {
           
            #region IValueConverter Members
            public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
            {
          /* your conditions here i.e Age<=0 */     
           if ((Int64)value <= 0)
             /*Return red color*/
                    return Brushes.Red;
                else
            /*Return the default color*/                  
                    return Brushes.White;
            }
            public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
            {
                return null;
            }
            #endregion
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
