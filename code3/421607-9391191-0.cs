    public class Foo
    {
        public string Bar { get; set; }
    }
    
    public struct Baz
    {
        public string Bazinga { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var hashtable1 = new Dictionary<string, Foo>
            {
                { "key1", new Foo { Bar = "old bar" } }
            };
            var hashtable2 = new Dictionary<string, Baz>
            {
                { "key1", new  Baz { Bazinga = "old bazinga" } }
            };
    
            var foo = hashtable1["key1"];
            foo.Bar = "new bar";
            var bar = hashtable2["key1"];
            bar.Bazinga = "new bazinga";
    
            Console.WriteLine(hashtable1["key1"].Bar);
            Console.WriteLine(hashtable2["key1"].Bazinga);
        }
    }
