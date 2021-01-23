    public class A<T>
    {
        public void Act<U>() where U : T
        {
            Console.Write("a");
        }
    }
    static void Main(string[] args)
    {
      A<IEnumerable> a = new A<IEnumerable>();
      a.Act<List<int>>();
    }
