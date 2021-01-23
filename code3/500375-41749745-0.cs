    void Main()
    {
        var path = @"C:\Users\User\AppData\Local\Temp\sample.xml";
        var text = File.ReadAllText(path);
        var surrounded = "<test xmlns=\"http://www.ya.com\">" + text + "</test>";
        var xe = XElement.Parse(surrounded);
        
        xe.Dump();
        xe.StripNamespaces().Dump();
        
        var sampleText = "<test xmlns=\"http://www.ya.com\"><div class=\"child\" xmlns:diag=\"http://test.com\"> ** this is some text **</div></test>";
        xe = XElement.Parse(sampleText);
        xe.Dump();
        xe.StripNamespaces().Dump();
    }
    
    public static class Extensions
    {
        public static XNode StripNamespaces(this XNode n)
        {
            var xe = n as XElement;
            if(xe == null)
                return n;
            var contents = 
                // add in all attributes there were on the original
                xe.Attributes()
                // eliminate the default namespace declaration
                .Where(xa => xa.Name.LocalName != "xmlns")
                .Cast<object>()
                // add in all other element children (nodes and elements, not just elements)
                .Concat(xe.Nodes().Select(node => node.StripNamespaces()).Cast<object>()).ToArray();
            var result = new XElement(XNamespace.None + xe.Name.LocalName, contents);
            return result;
    
        }
        
    #if !LINQPAD
        public static T Dump<T>(this T t, string description = null)
        {
            if(description != null)
                Console.WriteLine(description);
            Console.WriteLine(t);
            return t;
        }
    #endif
    }
