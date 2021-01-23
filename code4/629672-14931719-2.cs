    public class ViewModelBase
    {
        // base class code
    }
    public class DictionaryViewModel<T> : ViewModelBase
    {
        public DictionaryViewModel()
        {
            Rows = new ObservableCollection<T>();
        }
        private ObservableCollection<T> rows;
        public ObservableCollection<T> Rows
        {   
            get
            {
                return rows;
            }
            set
            {
                rows = value;
                RaisePropertyChanged("Rows");
            }
        }
    }
