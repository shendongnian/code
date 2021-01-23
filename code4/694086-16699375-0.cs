    interface IListFactory
    {
       IList GetList();
    }
    class GenericListFactory<T>
    {
       public IList GetList() { return new List<T>(); }
    }
