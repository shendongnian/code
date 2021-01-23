    public class JsonNetSerializerFactory :ISerializerFactory 
    {
        public ISerializer<T> Create<T>()
        {
            return new JsonNetSerializer<T>();
        }
        public class JsonNetSerializer<T> : ISerializer<T>
        {
            public T Deserialize(string input, String fromCharset, String toCharset)
    
            {
               String changedString = SysUtil.StringEncodingConvert(input, fromCharset,toCharset);
    
                return JsonConvert.DeserializeObject<T>(changedString  );
            }
    
            public IList<T> DeserializeList(string input, String fromCharset, String toCharset)
            {
             String changedString =  SysUtil.StringEncodingConvert(input, fromCharset,toCharset);
    
                return JsonConvert.DeserializeObject<IList<T>>(changedString);
            }
        }
    }
  
