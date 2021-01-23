    public class RepeaterItem<T1,T2>
    {
        public T1 Parent { get; set; }
        public T2 Current { get; set; }
        public RepeaterItem(T1 parent, T2 current)
        {
            Parent = parent;
            Current = current;
        }
    }
