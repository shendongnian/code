	String     parameter=@"<HostName>Arasanalu</HostName>
                                 <AdminUserName>Administrator</AdminUserName>
                                 <AdminPassword>A1234</AdminPassword>
                                 <PlaceNumber>38</PlaceNumber>";
    
    // Set the validation settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.DtdProcessing= DtdProcessing.Parse;
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema |
    XmlSchemaValidationFlags.AllowXmlAttributes |
    XmlSchemaValidationFlags.ReportValidationWarnings |
    XmlSchemaValidationFlags.ProcessIdentityConstraints |
    XmlSchemaValidationFlags.ProcessSchemaLocation;
   
    settings.Schemas.Add("xs",XmlReader.Create(new StringReader(
       @"<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
            <xs:element name=""blah""></xs:element>
         </xs:schema>"), settings));
    settings.ValidationEventHandler += (s,e) => 
          { 
            throw new XmlSchemaValidationException(e.Message); 
          };
    try
    {
      // Create the XmlReader object.
      XmlReader xmlrdr = XmlReader.Create(
                      new StringReader("<root>" + parameter + "</root>"), settings);
      // Parse the file. 
      while (xmlrdr.Read());
    }
    catch (XmlSchemaValidationException ex)
    {
      Console.WriteLine(
              "The file could not read the value at XML  format is not correct due to" + ex);
     }
    
