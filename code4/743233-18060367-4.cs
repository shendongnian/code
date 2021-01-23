    public partial class MainWindow : Window
    {
        #region Public
        public string FirstString
        {
            get { return (string)GetValue(FirstStringProperty); }
            set { SetValue(FirstStringProperty, value); }
        }
        public string SecondString
        {
            get { return (string)GetValue(SecondStringProperty); }
            set { SetValue(SecondStringProperty, value); }
        }
        public string ThirdString
        {
            get { return (string)GetValue(ThirdStringProperty); }
            set { SetValue(ThirdStringProperty, value); }
        }
        public string FourthString
        {
            get { return (string)GetValue(FourthStringProperty); }
            set { SetValue(FourthStringProperty, value); }
        }
        #region Dependency Properties
        public static readonly DependencyProperty FirstStringProperty = DependencyProperty.Register("FirstString", typeof(string), typeof(MainWindow), new PropertyMetadata("default value"));
        public static readonly DependencyProperty SecondStringProperty = DependencyProperty.Register("SecondString", typeof(string), typeof(MainWindow), new PropertyMetadata("default value"));
        public static readonly DependencyProperty ThirdStringProperty = DependencyProperty.Register("ThirdString", typeof(string), typeof(MainWindow), new PropertyMetadata("default value"));        
        public static readonly DependencyProperty FourthStringProperty = DependencyProperty.Register("FourthString", typeof(string), typeof(MainWindow), new PropertyMetadata("default value"));
        #endregion
        #endregion
        public MainWindow()
        {
            InitializeComponent();    
            FirstString = "First";
            SecondString = "Second";
            ThirdString= "Third";
            FourthString= "Fourth";
            this.DataContext = this;
        }
    }
