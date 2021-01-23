        public partial class MainWindow : Window
        {
        public static readonly DependencyProperty MonthsProperty = DependencyProperty.Register(
            "Months", 
            typeof(List<string>), 
            typeof(MainWindow), 
            new PropertyMetadata(new CultureInfo("en-US").DateTimeFormat.MonthNames.Take(12).ToList()));
        public List<string> Months
        {
            get
            {
                return (List<string>)this.GetValue(MonthsProperty);
            }
            set
            {
                this.SetValue(MonthsProperty, value);
            }
        }
        public MainWindow()
        {
            InitializeComponent();            
        }
    }
