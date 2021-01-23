    [Serializable]
    public class MyDataStorage
    {
        // some members
        public void Store( String filename )
        {
            XmlSerializer serializer = new XmlSerializer( typeof( MyDataStorage ) );
            using ( FileStream stream = File.OpenWrite( filename ) )
            {
                serializer.Serialize( stream, this );
            }
        }
    
        public static MyDataStorage Load(String filename )
        {
            XmlSerializer serializer = new XmlSerializer( typeof( MyDataStorage ) );
            object deserialized;
            using ( FileStream stream = File.OpenRead( filename ) )
            {
                deserialized = serializer.Deserialize( stream );
            }
            return (MyDataStorage) deserialized;
        }
    }
