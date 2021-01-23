    public class DataTableWithNotification : INotifyPropertyChanged
    {
        private DataTable _theTable = new DataTable();
        public DataTableWithNotification()
        {
        }
        public DataTableWithNotification(DataTable dt)
        {
            _theTable = dt;
        }
        public DataTable Table
        {
            get { return _theTable; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeTableAndNotify(DataTable newTable)
        {
            _theTable = newTable;
            OnPropertyChanged("Table");
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
