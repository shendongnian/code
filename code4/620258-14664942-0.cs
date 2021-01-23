    public class SortableObservableCollection<T, TKey> : ObservableCollection<T>
    {
        public void Sort(Func<T, TKey> keySelector, int skip = 0)
        {
            //...
        }
        public Func<T, TKey> Key1 { get; set; }
    }
