    void Main()
    {
        var enumerableThing = Foo.GetEnumerable();    
        var asArray = enumerableThing.Cast<object>().ToArray();
        
        var allContainedTypes = asArray.Select(x => x.GetType()).Distinct().ToArray();
        var ser = new XmlSerializer(asArray.GetType(), allContainedTypes);
        var sb = new StringBuilder();
        using(var sw = new StringWriter(sb))
        using(var xw = XmlWriter.Create(sw))
            ser.Serialize(xw, asArray);
            
        sb.ToString().Dump();
    }
    public class Foo
    {
        public static IEnumerable GetEnumerable()
        {
            return new[] { 1, 2, 3, 4, 5, 6, 7 };
        }
        public static IEnumerable GetEnumerable2()
        {
            return new object[] { "1", 2, "bob", 4, null, 6, 7 };
        }
    }
