    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class VisibilityToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            GridLength height = new GridLength();
            var visiblity = (Visibility)value;
            switch(visiblity)
            {
                case Visibility.Collapsed:
                    height = new GridLength(0, GridUnitType.Auto);
                    break;
                case Visibility.Visible:
                    height = new GridLength(1, GridUnitType.Star);
                    break;
                case Visibility.Hidden:
                    height = new GridLength(0, GridUnitType.Auto);
                    break;
            }
            return height;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
