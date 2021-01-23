    public interface ICollectionWidget<T>
    {
        IEnumerable<T> GetItems();
    }
    public class CollectionWidget : ICollectionWidget<int>
    {
        public IEnumerable<int> GetItems()
        {
            var i = 0;
            while (i++ < 10)
            {
                yield return i;
            }
            yield break;
        }
    }
