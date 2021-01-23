    public class CustomList<T> : List<T>
    {
        public event EventHandler<ChangeListCountEventArgs> ListCountChanged;
        public new int Count
        {
            get
            {
                ListCountChanged?.Invoke(this, new ChangeListCountEventArgs(base.Count));
                return base.Count;
            }
        }
        public CustomList()
        { }
        public CustomList(List<T> list) : base(list)
        { }
        public CustomList(CustomList<T> list) : base(list)
        { }
    }
