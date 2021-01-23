    class Program
    {
        static void Main()
        {
            var xml =
            @"
            <bookstore>
              <book genre='novel' ISBN='10-861003-324'>
                <title>The Handmaid's Tale</title>
                <price>19.95</price>
              </book>
              <book genre='novel' ISBN='1-861001-57-5'>
                <title>Pride And Prejudice</title>
                <price>24.95</price>
              </book>
            </bookstore>
            ";
            using (var reader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(reader))
            {
                var bookFound = false;
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "book")
                    {
                        var isbn = xmlReader.GetAttribute("ISBN");
                        bookFound = isbn == "1-861001-57-5";
                    }
    
                    if (bookFound && xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "title")
                    {
                        Console.WriteLine("title: {0}", xmlReader.ReadElementContentAsString());
                    }
                    if (bookFound && xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "price")
                    {
                        Console.WriteLine("price: {0}", xmlReader.ReadElementContentAsString());
                    }
                }
            }
        }
    }
