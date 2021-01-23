    class BaseClassViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                Debug.Print(info);
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
