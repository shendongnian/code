       class AddIt : IEnumerable
       {
          public void Add(String foo) { Console.WriteLine(foo); }
    
          public IEnumerator GetEnumerator()
          {
             return null; // in reality something else
          }
       }
    
       class Program
       {
          static void Main(string[] args)
          {
             var a = new AddIt() { "hello", "world" };
    
             Console.Read();
          }
       }
