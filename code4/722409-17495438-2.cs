    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DataTable currentTable;
    
        public DataTable CurrentTable
        {
            get
            {
                return this.currentTable;
            }
            set
            {
                this.currentTable = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentTable"));
            }
        }
    
        public MainWindowViewModel()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Column1");
            table.Columns.Add("Column2");
            table.Rows.Add("This is column1", "this is column2");
    
            CurrentTable = table;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
