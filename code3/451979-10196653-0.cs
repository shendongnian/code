    public class MainWindow : Window
    {
        // ...
        public void SetPage(UserControl page)
        {
             this.Content = page;
        }
    }
    // ...
    public static class Pages
    {
        private FirstUserControl _first;
        private SecondUserControl _second;
        private ThirdUserControl _third;
        private MainWindow _window = Application.Current.MainWindow;
        public UserControl First
        {
            get 
            { 
                if (_first == null) 
                    _first =  new FirstUserControl();
                return _first;
            }
        }
        // ...
    }
    // Somewhere in B (after A -> B)
        MainWindow.SetPage(Pages.First);
