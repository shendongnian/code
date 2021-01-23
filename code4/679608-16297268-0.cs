            public Form1()
            {
            InitializeComponent();
            XmlTextReader xreader = new XmlTextReader("YourXML.xml");
            string elem = "";
            while (xreader.Read()) //Read per line (and ?Withspace? (Pls correct me here))
            {
                switch (xreader.NodeType) //Is the line a Element(<General>;<Component>;<Foo>;<Bar>) or Text(value1)
                {
                    case XmlNodeType.Element:
                        if (xreader.Name.ToString().Contains("Foo"))
                            elem = xreader.Name;
                        else if (xreader.Name.ToString().Contains("Bar"))
                            elem = xreader.Name;
                        break;
    
                    case XmlNodeType.Text:
                        {
                            if (elem == "Foo")
                            {
                                string value1 = xreader.Value;
                            }
                            else if (elem == "Bar")
                            {
                                string value2 = xreader.Value;
                            }
                        }
                        break;
    
    
                }
            }
            xreader.Close();
        }
