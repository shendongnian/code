    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class MyViewModel
    {
        public ObservableCollection<MyEntity> Entities { get; private set; }
        public ICollectionView EntitiesView
        {
            if (view == null)    
            {
                view = new ListCollectionView(Entities);
            }
            return view;
        }
        private ICollectionView view;
    }
