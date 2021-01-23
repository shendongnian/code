    public interface ITree<TSelf, TItem> where TSelf : ITree<TSelf, TItem>
    {
        TSelf Union(TSelf other);
        // ...
    }
     
    public class AvlTree<TItem> : ITree<AvlTree<TItem>, TItem> {
        public AvlTree<TItem> Union(AvlTree<TItem> other) {
            return other;
        }
    }
