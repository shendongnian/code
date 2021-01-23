    public class DictionaryViewModel<T> : ViewModelBase
    {
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
    
        public DictionaryViewModel(IEnumerable<T> collection)
        {
            Rows = new ObservableCollection<T>(collection);
        }
    }
