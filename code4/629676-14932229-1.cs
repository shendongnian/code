    public class DictionaryViewModel<T> : ViewModelBase
    {
        private ObservableCollection<T> _rows;
        public ObservableCollection<T> Rows
        {
             get
             {
                  return _rows;
             }
             set
             {
                  _rows = value;
                  RaisePropertyChanged("Rows");
             }
        }
    }
