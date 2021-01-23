    public sealed partial class YourPage : Page
    {
        public ViewModels.YourPageViewModel ViewModel { get; set; }
        public YourPage()
        {
            this.InitializeComponent();
            if (DesignMode.DesignModeEnabled) return;
            this.DataContextChanged += (s, e) =>
            {
                ViewModel = DataContext as ViewModels.YourPageViewModel;
            };
        }
    }
