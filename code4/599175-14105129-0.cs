    public class Foo
    {
        public ValidatedStringCollection Bars = new ValidatedStringCollection(10);
    }
    public class ValidatedStringCollection : Collection<string>
    {
        int _maxStringLength;
        public ValidatedStringCollection(int MaxStringLength)
        {
            _maxStringLength = MaxStringLength;
        }
        protected override void InsertItem(int index, string item)
        {
            if (item.Length > _maxStringLength)
            {
                throw new ArgumentException(String.Format("Length of string \"{0}\" is beyond the maximum of {1}.", item, _maxStringLength));
            }
            base.InsertItem(index, item);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo x = new Foo();
            x.Bars.Add("A");
            x.Bars.Add("CCCCCDDDDD");
            //x.Bars.Add("This string is longer than 10 and will throw an exception if uncommented.");
            foreach (string item in x.Bars)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
