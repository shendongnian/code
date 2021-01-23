    public class AvalonTestModel : INotifyPropertyChanged
    {
        private int _offset;
        public int Offset 
        { 
            get { return _offset; } 
            set 
            { 
                _offset = value; 
                RaisePropertyChanged("Offset"); 
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
