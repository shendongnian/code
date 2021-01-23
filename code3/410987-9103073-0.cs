    class Program
    {
        static void Main(string[] args)
        {
            var g = new Bar();
            g.Parse(null);
            var f = new Foo();
            f.Export(null);
        }
    }
    public class Foo : IExporter<Foo>
    {
        public void Export(Foo obj)
        {
        }
    }
    public class Bar : IParser<Bar>
    {
        public Bar Parse(Workbook workbook)
        {
            return null;
        }
    }
