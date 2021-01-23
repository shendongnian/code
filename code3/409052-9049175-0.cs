    public class BasicClass
	{
		public int BasicProperty { get; set; }
	}
    class Program
    {
        static void Main(string[] args)
        {
            List<BasicClass> lst = new List<BasicClass>();
            lst.Add(new BasicClass {BasicProperty=5});
            lst.Add(new BasicClass { BasicProperty = 6 });
            foreach (var item in lst)
            {
                item.BasicProperty++;
            }
            Console.WriteLine("{0}, {1}", lst[0].BasicProperty, lst[1].BasicProperty);
            Console.ReadLine();
        }
    }
