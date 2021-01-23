    public sealed class SpecificDocGenerator : AbstractDocGenerator
    {
        private static readonly SpecificDocGenerator _instance;
    
        static SpecificDocGenerator
        {
           _instance = new SpecificDocGenerator();
        }
    
        public SpecificDocGenerator Instance
        {
            get { return _instance; }
        }
    
        private SpecificDocGenerator()
        {
        }
    
        public byte[] GenerateItDoc(DocInfo info)
        {
           //Here the document is generated and returned as byte array
        }
    
        private byte[] GetResource(string name)
        {
            //Gets a local resource (as example an image)
        }
    }
