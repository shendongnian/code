    interface ISerializer 
    {
        void Serialize(object obj);
    }
    class BinarySerializer : ISerializer
    {
        public void Serialize(object obj) 
        {
            // serialize obj as binary stream
        }
    }
    class XMLSerializer : ISerializer
    {
        public void Serialize(object obj) 
        {
            // serialize obj as XML
        }
    }
    // ...
    class PersistanceManager
    {
        private ISerializer serializer;
 
        public PersistanceManager(ISerializer serializer)
        {
            this.serializer = serializer;
        }
 
        public void Persist(object[] objects) 
        {
             foreach(object obj in objects)
             {
                  serializer.Serialize(obj);
             }
        }
    }
