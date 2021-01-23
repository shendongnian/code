    public class User : INotifyPropertyChanged
    {
        private string _textA;
        private string _textB;
    
        public string TextA
        {
            get { return _textA; }
            set { _textA = value; NotifyPropertyChanged("TextA"); }
        }
    
        public string TextB
        {
            get { return _textB; }
            set { _textB = value; NotifyPropertyChanged("TextB"); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
