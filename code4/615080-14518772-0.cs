    public int CompareTo(object obj)
    {
      if (object.ReferenceEquals(null, obj))
        return 1;
      Flow flow = obj as Flow;
      if (flow == null)
        throw new ArgumentException("Object is not of type Flow");
      return this.Name.CompareTo(flow.Name);
    }
