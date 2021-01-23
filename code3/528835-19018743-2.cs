    public class DataContractSystemJsonSerializer : XmlObjectSerializer
    {
        protected DataContractJsonSerializer innerSerializer;
    
    
        public DataContractSystemJsonSerializer(Type t)
        {
            this.innerSerializer = new DataContractJsonSerializer (t);
        }
        ...
    
        public override Object ReadObject(Stream stream)
        {
            Object obj = null;
            MemoryStream out = new MemoryStream();
            Byte[] buf = new Byte[64];
            stream.Read(buf,0,64);
            int i = 0;
            while(stream.Read(buf,i,1))
            {
              convertDatesInBuffer(&buf, &i);              
              out.write(buf, i, 1);
              
              i = (i+1)%64;
            }
            
            return innerSerializer.ReadObject(out);
        }
    }
