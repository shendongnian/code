    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                if (DataContext == null)
                    DataContext = new YourPageViewModel();
            };
        }
    }
