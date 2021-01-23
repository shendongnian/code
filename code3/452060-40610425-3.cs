    var toolsFactory = new SimpleSerializationToolsFactory();
    
    // Register your config class
    toolsFactory.Configurations.Add(new PersonConfig());
    
    // If you want to use property encryption you must register your implementation of IPropertyEncryption, e.g.:
    toolsFactory.EncryptionAlgorithm = new Base64PropertyEncryption(); 
    
    ExtendedXmlSerializer serializer = new ExtendedXmlSerializer(toolsFactory);
