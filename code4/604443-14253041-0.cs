    interface ICollection
    {
        void DoSomething(object item);
    }
    interface ICollection<ItemType> : ICollection
    {
        void DoSomething(ItemType item);
    }
    
    class Collection<ItemType> : ICollection<ItemType>
    {
        void ICollection.DoSomething(Object item)
        {
            DoSomething((ItemType)item);
        }
        public void DoSomething(ItemType item)
        {
            //...
        }
    }
