    class ABCCollection : List<ABC>
    {
      public ABC this[int id]
      {
        get { return this.Where(abc => abc.ID == id).FirstOrDefault(); }
      }
    }
