         private ObservableCollection<DataGridColumn> _dataGridColumns;
         public ObservableCollection<DataGridColumn> DataGridColumns
         {
             get
             {
                 if (_dataGridColumns == null)
                     _dataGridColumns = new ObservableCollection<DataGridColumn>()
                     {
                         new DataGridTextColumn()
                         {
                             Header = "Column1"
                         }
                     };
                 return _dataGridColumns;
             }
             set
             {
                 _dataGridColumns = value;
                 OnPropertyChanged("DataGridColumns");
             }
         }
