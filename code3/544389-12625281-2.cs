    using(var stream = new MemoryStream())
    {
        using(var streamWriter = new StreamWriter(stream))
        {
            streamWriter.Write(@"<a>
                                     <b>test
                                         <c>test2</c>
                                     </b>
                                 </a>");
            streamWriter.Flush();
            streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            var doc = XDocument.Load(stream);
            Console.WriteLine(doc.Element("a").Element("b").FirstNode.ToString());
        }
    }
