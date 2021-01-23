    using System.Xml;
    	List<string> values= new List<string>();	
        XmlTextReader reader = new XmlTextReader ("books.xml");
        while (reader.Read()) 
        {
               switch (reader.NodeType) 
               {
                       while (reader.MoveToNextAttribute()) // Read the attributes.
                         values.add(reader.Value);
                       break;
             case XmlNodeType.Text: //Display the text in each element.
                         values.add(reader.Value);
                       break;
             case XmlNodeType. EndElement: //Display the end of the element.
              Console.WriteLine(">");
                       break;
               }
           }
