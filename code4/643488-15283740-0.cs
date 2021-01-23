    // Create the XML fragment to be parsed. 
    string xmlFrag  = 
    @"<item attr1='  test A B C
        1 2 3'/>
      <item attr2='&#01;'/>";                         
    XmlTextReader reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);
    // Show attribute value normalization.
    reader.Read();
    reader.Normalization = false;
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr1"));
    reader.Normalization = true;
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr1"));
