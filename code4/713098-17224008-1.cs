	private static void TestGeneratedXML()
	{
		MyBox livro = new MyBox { Header = "Livro", Text = "Nome\r\nAutor" };
		MyBox autor = new MyBox { Header = "Autor", Text = "Nome" };
		Connection hasAutors = new Connection
		{
			Box1 = livro,
			Box2 = autor,
			Node1 = new Node { Title = "1" },
			Node2 = new Node { Title = "*" }
		};
		MyBox[] boxes = { livro, autor };
		Connection[] connections = { hasAutors };
		XElement userInformation = new XElement("Diagrama");
		foreach (MyBox b in boxes)
		{
			userInformation.Add(new XElement("Entidade",
									new XElement("Nome", b.Header),
									new XElement("Atributo", b.Text)));
		}
		foreach (Connection c in connections)
		{
			userInformation.Add(new XElement("Relação",
									new XElement("Entidade1",
										new XAttribute("Nome", c.Box1.Header),
										new XAttribute("Cardinalidade", c.Node1.Title)),
									new XElement("Entidade2",
										new XAttribute("Nome", c.Box2.Header),
										new XAttribute("Cardinalidade", c.Node2.Title))));
		}
		StringWriter sw = new StringWriter();
		XmlWriter xmlw = new XmlTextWriter(sw);// { Settings = new XmlWriterSettings { Indent = true } };
		userInformation.WriteTo(xmlw);
		string xml = sw.ToString();
		XDocument doc = XDocument.Parse(xml);
		MyBox[] outBoxes = doc.Root.Elements("Entidade")
								   .Select(e => new MyBox { Header = e.Element("Nome").Value, Text = e.Element("Atributo").Value })
								   .ToArray();
		Connection[] outConnections = doc.Root.Elements("Relação")
										   .Select(e => new Connection
										   {
											   Box1 = outBoxes.Single(b => b.Header == e.Element("Entidade1").Attribute("Nome").Value),
											   Box2 = outBoxes.Single(b => b.Header == e.Element("Entidade2").Attribute("Nome").Value),
											   Node1 = new Node { Title = e.Element("Entidade1").Attribute("Cardinalidade").Value },
											   Node2 = new Node { Title = e.Element("Entidade1").Attribute("Cardinalidade").Value },
                                               Line = new Line()
										   })
										   .ToArray();
    
	    foreach (MyBox box in outBoxes)
    	{
    		box.MouseLeftButtonDown += Box_MouseLeftButtonDown;
    		box.MouseLeftButtonUp += Box_MouseLeftButtonUp;
    		box.MouseMove += Box_MouseMove;
    
    		canvas.Children.Add(box);
    	}
        RefreshLinesPositions();
	}
