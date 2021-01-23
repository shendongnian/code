    using(var stream = new MemoryStream())
    {
        using(var streamWriter = new StreamWriter(stream))
        {
            streamWriter.Write(@"<a>
                                     <b>test
                                         <c>test2</c>
                                     </b>
                                 </a>");
        }
        var doc = XDocument.Load(stream);
        doc.Element("a").Element("b").Value;
    }
