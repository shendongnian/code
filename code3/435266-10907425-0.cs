    public class A
    {
        public void Foo()
        {
            var products =from u in XDoc.Descendants("product")
            select new C
            {
                Urunkod = u.Element("productId"),
                                UrunAdi = u.Element("title"),
            };
        }
    }
    public class B
    {
        public void Bar(IEnumerable<C> cList)
        {
            foreach(var c in cList)
                Console.WriteLine(c.Urunkod);
        }
    }
    
    public class C
    {
        public XElement Urunkod {get;set;}
        public XElement Urunkadi {get;set;}
    }
