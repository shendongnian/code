    class StackHolder: Stack
    {
        public delegate void ItemAddedDelegate(object item);
        public event ItemAddedDelegate ItemAdded;
        public override void Push(object obj)
        {
            base.Push(obj);
            if (ItemAdded != null)
            {
                ItemAdded(obj);
            }
        }
    }
