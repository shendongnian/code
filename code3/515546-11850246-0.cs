    public class ViewModel : INotifyPropertyChanged {
        public ObservableCollection<Item> PagedItems {get;set;}
        private DispatcherTimer _timer;
        private ObservableCollection<Item> _itemsToPage;
        private int _itemsPerPage;
        private int _currentPage;
        public ViewModel() {
            _itemsToPage = new ObservableCollection<Item>(); // replace this with whatever your items are
            _timer = new DispatcherTimer {Interval = new TimeSpan(0,0,0,10)};
            _timer.Tick += NextPage;
            _timer.Start();
        }
        private void NextPage(object sender, object e) {
            if (_itemsToPage < _itemsPerPage) return;
            if (_currentPage * _itemsPerPage >= _itemsToPage) _currentPage = 1;
            else _currentPage++;
            // the key line
            PagedItems = new ObservableCollection<Item>(
                _itemsToPage.Skip((_currentPage-1) * _itemsPerPage)
                    .Take(_itemsPerPage));
            OnPropertyChanged("PagedItems") // you need to implement INotifyPropertyChanged
        }
    }
