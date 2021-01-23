    public class BooleanVisibilityConverter : IValueConverter
    {
        #region Constructors
        public BooleanVisibilityConverter()
            : this(true)
        { }
        public BooleanVisibilityConverter(bool collapseWhenInvisible)
            : base()
        {
            CollapseWhenInvisible = collapseWhenInvisible;
        }
        #endregion
        #region Properties
        public bool CollapseWhenInvisible { get; set; }
        public Visibility FalseVisibility
        {
            get
            {
                if (CollapseWhenInvisible)
                    return Visibility.Collapsed;
                else
                    return Visibility.Hidden;
            }
        }
        #endregion
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;
            if ((bool)value)
                return Visibility.Visible;
            else
                return FalseVisibility;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return true;
            return ((Visibility)value == Visibility.Visible);
        }
        #endregion
    }
