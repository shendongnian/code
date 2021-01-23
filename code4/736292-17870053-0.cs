    abstract class Node<N, T>
        where N : Node<N, T>  // Here is the recursive definition
        where T : IComparable<T>
    {
        T value;
        public N NextNode;
        public N GetLastNode()
        {
            N current = (N)this;
            while (this.NextNode != null)
            {
                current = current.NextNode;
            }
            return current;
        }
        // etc.
    }
