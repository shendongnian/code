    class EditStuffViewModel : ViewModelBase
    {
        public EditStuffViewModel (ObservableCollection<Choice> choices)
        {
            Choices = new CollectionViewSource() { Source = choices }.View;
            Choices.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
 
            ChoiceViews = new List<ICollectionView>();
            for (var i = 0; i < 10; i++) {
                ChoiceViews.Add(new CollectionViewSource() { Source = choices }.View);
            }
        }
        public IList<ICollectionView> ChoiceViews
        {
            get; private set;
        }
        //snip other properties
    }
