    public class MyCollectionView : ListCollectionView
    {
        public MyCollectionView(IList sourceCollection) : base(sourceCollection)
        {
            foreach (var item in sourceCollection)
            {
                if (item is INotifyPropertyChanged)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged +=
                                                      (s, e) => Refresh();
                }
            }
        }
    }
