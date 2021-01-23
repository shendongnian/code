    class MyCollection<C>
    {
        private List<C> list = new List<C>();
        
        public void Add<C>(C item)
        {
            list.Add(item);
        }
    }
