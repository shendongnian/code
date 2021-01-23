      var settings = new XmlReaderSettings();
      settings.IgnoreComments = true;
      settings.IgnoreProcessingInstructions = true;
      settings.IgnoreWhitespace = true;
      using (var reader = XmlReader.Create(filePath, settings))
      {
        if (reader.IsStartElement("gpx"))
        {
          string defaultNamespace = reader["xmlns"];
          XmlSerializer serializer = new XmlSerializer(typeof(Gpx), defaultNamespace);
          gpx = (Gpx)serializer.Deserialize(reader);
        }
      }
