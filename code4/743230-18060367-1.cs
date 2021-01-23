    public partial class MainWindow : Window
    {
        public string FirstString { get; set; }
        public string SecondString { get; set; }
        public string ThirdString { get; set; }
        public string FourthString { get; set; }
        public static readonly DependencyProperty FirstStringProperty = DependencyProperty.Register(
            "FirstString", typeof(string), typeof(NAMEOFTHEPAGEORCONTROL), new PropertyMetadata("default value"));
        public string FirstString
        {
            get { return (string)GetValue(FirstStringProperty); }
            set { SetValue(FirstStringProperty, value); }
        }
        public static readonly DependencyProperty SecondStringProperty = DependencyProperty.Register(
            "SecondString", typeof(string), typeof(NAMEOFTHEPAGEORCONTROL), new PropertyMetadata("default value"));
        public string SecondString
        {
            get { return (string)GetValue(SecondStringProperty); }
            set { SetValue(SecondStringProperty, value); }
        }
        public static readonly DependencyProperty ThirdStringProperty = DependencyProperty.Register(
            "ThirdString", typeof(string), typeof(NAMEOFTHEPAGEORCONTROL), new PropertyMetadata("default value"));
        public string ThirdString
        {
            get { return (string)GetValue(ThirdStringProperty); }
            set { SetValue(ThirdStringProperty, value); }
        }
        public static readonly DependencyProperty FourthStringProperty = DependencyProperty.Register(
            "FourthString", typeof(string), typeof(NAMEOFTHEPAGEORCONTROL), new PropertyMetadata("default value"));
        public string FourthString
        {
            get { return (string)GetValue(FourthStringProperty); }
            set { SetValue(FourthStringProperty, value); }
        }
        public MainWindow()
        {
            InitializeComponent();    
            FirstString = "First";
            SecondString = "Second";
            ThirdString= "Third
            FourthString= "Fourth";
            this.DataContext = this;
        }
    }
