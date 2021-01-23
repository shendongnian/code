    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        {
    public class CheckedToLengthConverter : System.Windows.Markup.MarkupExtension, IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return System.Convert.ToBoolean(value) ? new GridLength(1, GridUnitType.Star) : new GridLength(0, GridUnitType.Pixel);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return Binding.DoNothing;
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    //etc...
