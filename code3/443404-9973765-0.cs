     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private string textdisplayed;
        public string Textdisplayed
        {
            get { return textdisplayed; }
            set
            {
                textdisplayed = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Textdisplayed"));
            }
        }
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        #endregion
    }
