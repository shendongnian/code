    public class SomeClass: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool number0;
        public bool Number0
        {
            get { return number0; }
            set
            {
                number0 = value;
                this.NotifyPropertyChanged("Number0");
            }
        }
        private bool sum;
        public bool Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                this.NotifyPropertyChanged("Sum");
            }
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
