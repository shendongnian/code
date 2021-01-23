    class MainViewModel : NotificationObject
        {
            public MainViewModel()
            {
                _myItems.Add("aaa");
                _myItems.Add("abb");
                _myItems.Add("aab");
                _myItems.Add("bbb");
                _myItems.Add("bcc");
                _myItems.Add("bbc");
    
                SearchItems = new DelegateCommand(this.OnSearchItems);
            }
    
            private string _searchText;
            public string SearchText
            {
                get { return _searchText; }
                set { _searchText = value; RaisePropertyChanged(() => SearchText); }
            }
    
            private ICollectionView _mySourceData;
            public ICollectionView MySourceData
            {
                get { return CollectionViewSource.GetDefaultView(_myItems); }           
            }
    
            private List<string> _myItems = new List<string>();
    
            public ICommand SearchItems { get; private set; }
            private void OnSearchItems()
            {            
                MySourceData.Filter = (o) => { return string.IsNullOrEmpty(SearchText) ? true : (o as string).StartsWith(SearchText); };          
            }
        }
