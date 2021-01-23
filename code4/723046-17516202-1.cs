    class Scan : INotifyPropertyChanged
    {
        // Implementing the INotifyPropertyChanged interface:
        public event PropertyChangedEventHandler PropertyChanged;
        // A utility method to make raising the above event a little easier:
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        // Then, notify the view about changes whenever a property is set:
        private string operatorCode;
        public string OperatorCode
        {
            get { return operatorCode; }
            set { operatorCode = value; RaisePropertyChanged("OperatorCode"); }
        }
    }
