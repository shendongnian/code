    public class DataGridValidationViewModels
    {
        public DataGridValidationViewModels()
        {
            Items = new ObservableCollection<DataGridValidationViewModel>
                        {
                            new DataGridValidationViewModel(),
                            new DataGridValidationViewModel(),
                            new DataGridValidationViewModel(),
                            new DataGridValidationViewModel(),
                            new DataGridValidationViewModel(),
                            new DataGridValidationViewModel(),
                            new DataGridValidationViewModel(),
                        };
        }
        public IEnumerable<DataGridValidationViewModel> Items { get; set; }
    }
    public class DataGridValidationViewModel : ViewModelBase, IDataErrorInfo
    {
        public DataGridValidationViewModel()
        {
            _column1 = "Column 1";
            _column2 = "Column 2";
        }
        private string _column1;
        public string Column1
        {
            get { return _column1; }
            set
            {
                Set(() => Column1, ref _column1, value);
                Column2 = value;
            }
        }
        private string _column2;
        public string Column2
        {
            get { return _column2; }
            private set{ Set(()=>Column2, ref _column2, value);}
        }
        #region Implementation of IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Column1":
                        return Column1 == "Error" ? "There's an error in column 1!" : string.Empty;
                    case "Column2":
                        return Column1 == "Error" ? "There's an error in column 2!" : string.Empty;
                }
                return string.Empty;
            }
        }
        public string Error
        {
            get { return string.Empty; }
        }
        #endregion
    }
