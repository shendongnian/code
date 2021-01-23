        // Constructor
        public MainPage()
        {
            InitializeComponent();
            BindList();
            this.DataContext= this;
        }
        public class country 
        {
            public int CountryID { get; set; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        List<country> _lstCountry;
        public List<country> LstCountry
        {
            get{return _lstCountry;}
            set{
                if(_lstCountry!=value)
                {
                    _lstCountry = value;
                    NotifyPropertyChanged("LstCountry");
                }
            }
        }
        void BindList()
        {
            LstCountry = new List<country>();
            for (int i = 0; i <= 100; i++)
            {
                LstCountry.Add(new country { CountryID = i });
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listPickerCountrySignup.SelectedIndex = 15;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            listPickerCountrySignup.SelectedIndex = 25;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            listPickerCountrySignup.SelectedIndex = 39;
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            listPickerCountrySignup.SelectedIndex = 55;
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            listPickerCountrySignup.SelectedIndex = 75;
        }
    }
