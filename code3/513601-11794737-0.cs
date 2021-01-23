    public class Column : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string columnName;
        public bool anonymize;
        public string ColumnName
        {
            get { return columnName; }
            set
            {
                columnName = value; RaiseOnPropertyChanged("ColumnName");
            }
        }
        public bool Anonymize
        {
            get { return anonymize; }
            set { anonymize = value; RaiseOnPropertyChanged("Anonymize"); }
        }
        public void RaiseOnPropertyChanged(string propertyName)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propertyName));
        }
    }
