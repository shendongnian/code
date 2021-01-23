    XmlDocument xDoc = await XmlDocument.LoadFromUriAsync(new Uri(blog.URL)); //URL you're trying to read
            StringReader stringReader= new StringReader(xDoc.GetXml());
            XmlReader xmlReader = XmlReader.Create(stringReader);
            XDocument loadedPosts = XDocument.Load(xmlReader); //this can be done simpler using HttpClient.GetStringAsync
            XNamespace dc = "http://purl.org/dc/elements/1.1/";
            XNamespace content = XNamespace.Get("http://purl.org/rss/1.0/modules/content/"); //declare namespaces for dc:content
            var data = from query in loadedPosts.Descendants("item") //gets all the "item" tags
                       select new Post //class you must create
                       {
                           NombreBlog = (string)query.Parent.Element("title"), //then you simply change 'Element("title")' with 'Element("propertyYouWant")'
                           Titulo = (string)query.Element("title"),
                           Autor = (string)query.Element(dc + "creator"),
                           Contenido = (string)query.Element(content + "encoded"),
                           PubDate = (string)query.Element("pubDate"),
                           Link = (string)query.Element("link"),
                           ID = getId((string)query.Element("guid")),
                           Imagen = getImage((string)query.Element(content + "encoded"))
                       };
