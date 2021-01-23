    public class MyCollection : ObservableCollection<MyItem>, ICollectionViewFactory
    {
        public ICollectionView CreateView()
        {
            return new MyListCollectionView(this);
        }
    }
