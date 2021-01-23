    public class DictionaryViewModel<T> : ViewModelBase
    {
        private ObservableCollection<T> _rows;
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
