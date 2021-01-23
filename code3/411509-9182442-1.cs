    public class Orchard
    {
        private IDictionary<Type, object> _trees;
        //...
        public Tree<T> GetTree<T>()
        {
            return (Tree<T>)_trees[typeof(T)];
        }
    }
