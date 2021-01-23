    while (textReader.MoveToNextAttribute() || textReader.Read())
    { 
         switch (textReader.NodeType)
         {
             case XmlNodeType.Element:
                 Console.WriteLine(textReader.Name);
                 Console.WriteLine(textReader.Value);
                 break;
             //...
             case XmlNodeType.Attribute:
                 //use textReader.Name and textReader.Value here for attribute name and value
                 break;
        }
    }
