	books bks = new books();
	bks.bookNum = 2;
	bks.books = new books.book[]{ new books.book{name="first", records = new books.book.record[] {new books.book.record{borrowDate = DateTime.Now.ToString(), returnDate = DateTime.Now.ToString()}}}};
	System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(books));
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
    settings.Indent = true;
    settings.OmitXmlDeclaration = true;
    using(StringWriter textWriter = new StringWriter()) {
        using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) {
            serializer.Serialize(xmlWriter, bks);
        }
        return textWriter.ToString(); //This is the output as a string
    }
