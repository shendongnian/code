    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Items = new ObservableCollection<int>();
            for (int i = 0; i < 100; i++)
            {
                Items.Add(i);
            }
        }
        public ObservableCollection<int> Items
        {
            get { return (ObservableCollection<int>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<int>), typeof(MainWindow));
        
    }
    [ValueConversion(typeof(int), typeof(Brush))]
    public sealed class StateToBrush : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color stateColor = Colors.Yellow;
            switch ((int)value)
            {
                case 0:
                    stateColor = Colors.Green;
                    break;
                case 1:
                    stateColor = Colors.Red;
                    break;
            }
            return new SolidColorBrush(stateColor);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
