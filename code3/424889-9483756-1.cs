    [Serializable]
    public class MyObject
    {
      public int Id { get; set; }
      public object Item { get; set; }    // <---- Note type *object* here
    }
    [Serializable]
    public class MyItem
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }
