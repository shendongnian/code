      Type objectType = obj.GetType();
      XmlAttributeOverrides isNullAttOv = new XmlAttributeOverrides();
      AddIsNullableFieldAttributeOverride(objectType, isNullAttOv);
                
      XmlSerializer xmls = new XmlSerializer(objectType, isNullAttOv , null, null, null);
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Encoding = Encoding.UTF8;
      settings.Indent = true;
      settings.OmitXmlDeclaration = true;
      settings.CloseOutput = true;
      settings.IndentChars = new String(' ', 4);
      using (var stream = new MemoryStream())
      using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
      using (var writer = XmlWriter.Create(stream, settings))
      {
                    xmls.Serialize(writer, obj, null);
                    reader.BaseStream.Position = 0;
                    string serialiseXML = reader.ReadToEnd();
                    return serialiseXML; // break point here :)
      }
