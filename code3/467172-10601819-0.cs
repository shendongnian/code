     public class ObserCol: ObservableCollection<int>
    {
        private int _maxValue = 0;
        public ObserCol() { 
            base.CollectionChanged +=new NotifyCollectionChangedEventHandler(CollectionChanged);
        }
        public int MaxValue{
            get {
                return _maxValue;
            }
        }
        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //Can use Linq to get the Max or Other Aggregate values..
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                
            }
        }
    }
