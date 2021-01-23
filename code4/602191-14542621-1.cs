    Assembly myAssembly = Assembly.GetExecutingAssembly();
    using (Stream schemaStream = myAssembly.GetManifestResourceStream(resourceName)) {
      using (XmlReader schemaReader = XmlReader.Create(schemaStream)) {
        settings.Schemas.Add(null, schemaReader);
      }
    }
