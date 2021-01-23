    static void Main(string[] args)
    {
        using (Resource resource = new Resource())
        {
           foreach (var number in resource.GetNumbers())
           {
              if (number > 2)
                 break;
              Console.WriteLine(number);
           }
         }
         Console.Read();
     }
     public class Resource : IDisposable
     {
        private List<int> _numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        public IEnumerable<int> GetNumbers()
        {
           foreach (var number in _numbers)
              yield return number;
        }
        public void Dispose()
        {
           Console.WriteLine("Resource::Dispose()...");
        }
     }
