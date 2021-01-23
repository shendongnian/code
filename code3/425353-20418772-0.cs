      public void ReadXml(XmlReader reader)
      {
         reader.MoveToContent();
         Boolean isEmptyElement = reader.IsEmptyElement; 
         reader.ReadStartElement();
         if (!isEmptyElement)
         {
            // ...here comes all other properties deserialization
            object tag;
            if (ReadXmlObjectProperty(reader, "Tag", out tag))
            {
               Tag = tag;
            }
            reader.ReadEndElement();
         }
      }
      public void WriteXml(XmlWriter writer)
      {
         // ...here comes all other properties serialization
         WriteXmlObjectProperty(writer, "Tag", Tag);
      }
      public static bool ReadXmlObjectProperty(XmlReader reader, 
                                               string name,
                                               out object value)
      {
         value = null;
         // Moves to the element
         while (!reader.IsStartElement(name))
         {
            return false;
         }
         // Get the serialized type
         string typeName = reader.GetAttribute("Type");
            
         Boolean isEmptyElement = reader.IsEmptyElement; 
         reader.ReadStartElement();
         if (!isEmptyElement)
         {
            Type type = Type.GetType(typeName);
            if (type != null)
            {
               // Deserialize it
               XmlSerializer serializer = new XmlSerializer(type);
               value = serializer.Deserialize(reader);
            }
            else
            {
               // Type not found within this namespace: get the raw string!
               string xmlTypeName = typeName.Substring(typeName.LastIndexOf('.')+1);
               value = reader.ReadElementString(xmlTypeName);
            }
            reader.ReadEndElement();
         }
         return true;
      }
      public static void WriteXmlObjectProperty(XmlWriter writer, 
                                                string name,
                                                object value)
      {
         if (value != null)
         {
            Type valueType = value.GetType();
            writer.WriteStartElement(name);
            writer.WriteAttributeString("Type", valueType.FullName);
            writer.WriteRaw(ToXmlString(value, valueType));
            writer.WriteFullEndElement();
         }
      }
      public static string ToXmlString(object item, Type type) 
      {
         XmlWriterSettings settings = new XmlWriterSettings();
         settings.Encoding = Encoding.ASCII;
         settings.Indent = true;
         settings.OmitXmlDeclaration = true;
         settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
         using(StringWriter textWriter = new StringWriter()) 
         using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) 
         {
            XmlSerializer serializer = new XmlSerializer(type);
            serializer.Serialize(xmlWriter, item, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
            return textWriter.ToString();
         }
      }
