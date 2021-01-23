    var x = new foo() { lastname = "John ÐØë", city = "John ÐØë", other = "—" };
            
    using (var stream = new MemoryStream())
    using (var utf8writer = new StreamWriter(stream, Encoding.UTF8))            
    using (var latin1writer = new StreamWriter(stream, Encoding.GetEncoding("iso-8859-1")))
    {
        utf8writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        utf8writer.WriteLine("<foo>");
        utf8writer.Flush();
        latin1writer.WriteLine("  <lastname>" + SecurityElement.Escape(x.lastname) + "</lastname>");
        latin1writer.WriteLine("  <city>" + SecurityElement.Escape(x.city) + "</city>");
        latin1writer.Flush();
        utf8writer.WriteLine("  <other>" + SecurityElement.Escape(x.other) + "</other>");
        utf8writer.WriteLine("/<foo>");
        utf8writer.Flush();
        byte[] bytes = stream.ToArray();
    }
