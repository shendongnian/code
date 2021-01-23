      // Create an XmlTextWriter using a FileStream.
      Stream fs = new FileStream(filename, FileMode.Create);
      XmlWriter writer = 
      new XmlTextWriter(fs, Encoding.Unicode);
      // Serialize using the XmlTextWriter.
      serializer.Serialize(writer, yourObject);
      writer.Close();
