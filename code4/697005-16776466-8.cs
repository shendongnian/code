    public class DataGridSearchViewModel: PropertyChangedBase
    {
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                OnPropertyChanged("SearchString");
                ItemsView.Refresh();
            }
        }
        private ICollectionView _itemsView;
        public ICollectionView ItemsView
        {
            get { return _itemsView; }
        }
        private ObservableCollection<DataGridSearchModel> _items;
        public ObservableCollection<DataGridSearchModel> Items
        {
            get { return _items ?? (_items = new ObservableCollection<DataGridSearchModel>()); }
        }
        public DataGridSearchViewModel()
        {
            _itemsView = CollectionViewSource.GetDefaultView(Items);
            _itemsView.Filter = x => Filter(x as DataGridSearchModel);
            Enumerable.Range(0, 100)
                      .Select(x => CreateRandomItem())
                      .ToList()
                      .ForEach(Items.Add);
        }
        private bool Filter(DataGridSearchModel model)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();
            return model != null &&
                 ((model.LastName ?? string.Empty).ToLower().Contains(searchstring) ||
                  (model.FirstName ?? string.Empty).ToLower().Contains(searchstring) ||
                  (model.Address ?? string.Empty).ToLower().Contains(searchstring));
        }
        private DataGridSearchModel CreateRandomItem()
        {
            return new DataGridSearchModel
                       {
                           LastName = RandomGenerator.GetNext(1),
                           FirstName = RandomGenerator.GetNext(1),
                           Address = RandomGenerator.GetNext(4)
                       };
        }
    }
