    public interface ITree<T, X> where T : ITree<T, X>
    {
    	T Union(T other);
    }
    
    public class RedBlackTree<T> : ITree<RedBlackTree<T>, T>
    {
    	public RedBlackTree<T> Union(RedBlackTree<T> other)
    	{
    	}
    }
