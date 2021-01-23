    public class StringRes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
        public string Login
        {
            get { return Properties.Strings.Login; }
        }
        public string Password
        {
            get { return Properties.Strings.Password; }
        }
        public void NotifyLanguageChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Login"));
            PropertyChanged(this, new PropertyChangedEventArgs("Password"));
        }
    }
    public class MainWindow
    {
        private StringRes _resources;
        private void LanguageSelection_SelectionChanged()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = GetCurrentCulture();
            _resources.NotifyLanguageChanged();
        }
    }
