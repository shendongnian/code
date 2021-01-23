    public partial class TestWindow : Window
    {
        Person p;
        public TestWindow()
        {
            InitializeComponent();
            p = new Person();
            p.CountryOfOrigin = Country.Canada;
            DataContext = p;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p.CountryOfOrigin = Country.Mexico;
        }
    }
    public enum Country
    {
        Canada,
        UnitedStates,
        Mexico,
        Brazil,
    }
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Country _countryOfOrigin;
        public Country CountryOfOrigin
        {
            get
            {
                return _countryOfOrigin;
            }
            set
            {
                if (_countryOfOrigin != value)
                {
                    _countryOfOrigin = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("CountryOfOrigin"));
                }
            }
        }
    }
