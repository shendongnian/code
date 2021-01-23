    public Class TheClassHoldingYourObject
    {
        private static XmlSerializer _instance;
        public static Settings Load() 
        { 
            if(_instance != null) return _instance
            using (Stream stream = File.OpenRead(FileName)) 
            { 
                  XmlSerializer serializer = new XmlSerializer(typeof(Settings)); 
                  return (Settings)serializer.Deserialize(stream); 
            } 
        }
     }
