    public class TypeFilteredList : IList<Type>
    {
        private Type filterType;
        private List<Type> types = new List<Type>();
        public TypeFilteredList(Type filterType)
        {
            this.filterType = filterType;
        }
        private void CheckType(Type item)
        {
            if (item != null && !filterType.IsAssignableFrom(item))
                throw new ArgumentException("item");
        }
        public void Add(Type item)
        {
            CheckType(item);
            types.Add(item);
        }
        public void Insert(int index, Type item)
        {
            CheckType(item);
            types.Insert(index, item);
        }
...
    }
