    using DroopyExtensions;
    
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string>() {"One", "Two", "Tree"};
            var dataEnumerator = data.GetCircularEnumerator();
            while(dataEnumerator.MoveNext())
            {
                Console.WriteLine(dataEnumerator.Current);
            }
        }
    }
