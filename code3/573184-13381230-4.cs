    using System.ComponentModel;
    public class YourClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        protected void AddLogLine(String log)
        {
            // do your process
            NotifyPropertyChanged("Log");
        }
    }
