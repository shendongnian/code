    public class News: INews
    {
      public int Id {get; set;}
      public string Name {get; set;}
      public void Add(News news); //<-- invalid
      public void Remove(News news); //<-- invalid
    }
