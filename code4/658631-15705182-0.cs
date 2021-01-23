    public class Foo<T> where T : IEnumerable
    {
      public T Value { get; set; }
      public void Print()
      {
          foreach (var item in Value)
            Console.WriteLine(item);
      }
    }
