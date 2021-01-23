    public class instance : INotifyPropertyChanged
    {
        private int progress;
        public int Progress 
        {
            get { return progress; }
            set
            {
                if (progress != value)
                {
                    progress = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Progress"));
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /* Do the same with the remaining properties */
        public string User { get; set; }
        public string File { get; set; }
    }
