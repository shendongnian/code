    class Blob
    {
        public Texture2D texture;
        public Dictionary<byte, Color> blobType = new Dictionary<byte, Color>();
        
        public Blob() 
        {
            blobType.add(1, Color.White);
        }
    }
