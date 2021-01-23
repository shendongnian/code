    var s = new DataContractSerializer (typeof(Thing));
    using(var wr = XmlTextWriter.Create(
        @"test.xml", new XmlWriterSettings{Encoding=Encoding.UTF32}))
    {
        s.WriteObject(wr, new Thing{Foo="bar"});
    }
    public class Thing
    {	
        public string Foo { get; set; }
    }
