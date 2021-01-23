    public class MainView : Window
    {
        public MainView()
        {
            InititializeComponent();
            // It is just for simplicity. It would be better to use MVVM Light framework: ViewModel Locator!
            DataContext = new MainViewModel();
        }
    }
    
