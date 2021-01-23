    List<Book> BookList = new List<Book>();
    
                XmlDataDocument objDocument = new XmlDataDocument();
                objDocument.Load(@"Book.xml");
    
    
                XmlSerializer serializer = new XmlSerializer(typeof(Book));                
    
                foreach(XmlNode objItem in   objDocument.DocumentElement.ChildNodes)
                {
                    TextReader objTextReader = new StringReader(objItem.OuterXml);
    
                    using (XmlReader reader = XmlReader.Create(objTextReader))
                        {
                            BookList.Add((Book)serializer.Deserialize(reader));
                            reader.Close();
                        }
                }
