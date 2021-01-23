    public class GameInfo : INotifyPropertyChanged
    {
        public int Score { get; set; }
        public int counter = 0;
        public event PropertyChangedEventHandler PropertyChanged;
      
         private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
