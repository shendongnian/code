    /// <summary>
    /// This control has a dynamic/percentage width/height
    /// </summary>
    public class FluentPanel : ContentControl, IValueConverter
    {
        #region Dependencie Properties
    
        public static readonly DependencyProperty WidthPercentageProperty =
            DependencyProperty.Register("WidthPercentage", typeof(int), typeof(FluentPanel), new PropertyMetadata(-1, WidthPercentagePropertyChangedCallback));
    
        private static void WidthPercentagePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((FluentPanel)dependencyObject).OnWidthPercentageChange();
        }
    
        public int WidthPercentage
        {
            get { return (int)GetValue(WidthPercentageProperty); }
            set { SetValue(WidthPercentageProperty, value); }
        }
    
        public static readonly DependencyProperty HeightPercentageProperty =
            DependencyProperty.Register("HeightPercentage", typeof(int), typeof(FluentPanel), new PropertyMetadata(-1, HeightPercentagePropertyChangedCallback));
    
        private static void HeightPercentagePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((FluentPanel)dependencyObject).OnHeightPercentageChanged();
        }
    
        public int HeightPercentage
        {
            get { return (int)GetValue(HeightPercentageProperty); }
            set { SetValue(HeightPercentageProperty, value); }
        }
    
        #endregion
    
        #region Methods
    
        private void OnWidthPercentageChange()
        {
            if (WidthPercentage == -1)
            {
                ClearValue(WidthProperty);
            }
            else
            {
                SetBinding(WidthProperty, new Binding("ActualWidth") { Source = Parent, Converter = this, ConverterParameter = true });
            }
        }
    
        private void OnHeightPercentageChanged()
        {
            if (HeightPercentage == -1)
            {
                ClearValue(HeightProperty);
            }
            else
            {
                SetBinding(HeightProperty, new Binding("ActualHeight") { Source = Parent, Converter = this, ConverterParameter = false });
            }
        }
    
        #endregion
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)parameter)
            {
                // width
                return (double)value * (WidthPercentage * .01);
            }
            else
            {
                // height
                return (double)value * (HeightPercentage * .01);
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
