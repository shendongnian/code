    class EditStuffViewModel : ViewModelBase
    {
        public EditStuffViewModel (ObservableCollection<Choice> choices)
        {
            ChoiceViews = new List<ICollectionView>();
            for (var i = 0; i < 10; i++) {
                var viewSource = new CollectionViewSource() { Source = choices };
                viewSource.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                ChoiceViews.Add(viewSource.View);
            }
        }
        public IList<ICollectionView> ChoiceViews
        {
            get; private set;
        }
        //snip other properties
    }
