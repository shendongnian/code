    public IEnumerable<T> GetMany<T>()
    {
      using(var odb = OdbFactory("Example.db"))
      {
        return new BindingList<T>(odb.AsQueryable<T>().ToList());
      }
    }
