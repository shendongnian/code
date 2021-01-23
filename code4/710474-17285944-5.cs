    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new /* your view model */
            {
                Title = Guid.NewGuid().ToString(),
            };
        }
    }
