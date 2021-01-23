    // var xml = ** load xml string
    var document = XDocument.Parse(xml);
    
    foreach(var i in document.Root.Elements())
    {
        var num = ""; 
        var code = "";
        if(i.Attributes("num").Length > 0)
        {
            Console.WriteLine("Num: {0}", i.Attributes("num")[0].Value);
            Console.WriteLine("Code: {0}", i.Attributes("code")[0].Value);
        }
        else
        {
            Console.WriteLine("Num: {0}", i.Element("num").Value);
            Console.WriteLine("Code: {0}", i.Element("code").Value);
        }
    }
