    books bks = new books();
	books bks2 = null;
	bks.bookNum = 2;
	bks.allBooks = new books.book[] 
			{ 
				new books.book {
					name="book 1", 
					records = new books.book.record[] {
							new books.book.record{borrowDate = DateTime.Now.ToString(), returnDate = DateTime.Now.ToString()}
						}
					},
				new books.book { 
					name="book 2", 
					records = new books.book.record[] { 
							new books.book.record{borrowDate = DateTime.Now.ToString(), returnDate = DateTime.Now.ToString()}, 
							new books.book.record{borrowDate = DateTime.Now.ToString(), returnDate = DateTime.Now.ToString()}}
						},
			};
	string xmlString;
		
	System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(books));
			
	XmlWriterSettings settings = new XmlWriterSettings();
	settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
	settings.Indent = true;
	settings.OmitXmlDeclaration = true;
			
	XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
	// exclude xsi and xsd namespaces by adding the following:
	ns.Add(string.Empty, string.Empty);
		
	using(StringWriter textWriter = new StringWriter()) {
		using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) {
	   		serializer.Serialize(xmlWriter, bks, ns);
		}
		xmlString = textWriter.ToString(); //This is the output as a string
	}
	
	xmlString.Dump();
    // Deserialize the xml string now		
	using ( TextReader reader = new StringReader(xmlString) ) {
        bks2 = ( books )serializer.Deserialize(reader);
    }
	
	bks2.Dump();
