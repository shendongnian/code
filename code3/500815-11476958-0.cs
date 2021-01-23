    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class RootClass
    {
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name;
    
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender;
    }
    
        static void Main(string[] args)
        {
           var serializer = new DataContractJsonSerializer(typeof(RootClass[]));
            serializer.ReadObject(/*Input stream w/ JSON*/);
    
        }
    
