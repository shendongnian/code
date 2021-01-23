    public class ViewModelBase
    {
        // base class code
    }
    public class DictionaryViewModel : ViewModelBase
    {
        public DictionaryViewModel()
        {
            Rows = new ObservableCollection<Object>();
        }
        private ObservableCollection<Object> rows;
        public ObservableCollection<Object> Rows
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
