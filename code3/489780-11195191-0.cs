     public class Emp : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Working
        {
            get { return working_; }
            set
            {
                if (working_ != value)
                {
                    working_ = value;
                    retired_ = !working_;
                    OnPropertyChanged("Retired");
                    OnPropertyChanged("Working");
                }
               
            }
        }
        public bool Retired
        {
            get { return retired_; }
            set
            {
                if (retired_ != value)
                {
                    retired_ = value;
                    working_ = !retired_;
                    OnPropertyChanged("Retired");
                    OnPropertyChanged("Working");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private bool retired_;
        private bool working_;
        public void OnPropertyChanged(string PropertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
