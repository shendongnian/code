    public sealed partial class MainPage : LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new ViewModel();
        }
    }
