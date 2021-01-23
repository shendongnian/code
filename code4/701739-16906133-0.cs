        public class Class
        {
            
            public int Id { get; set; }
            
            public int MsgId { get; set; }
            
            public string ExceptionDetails { get; set; }
            public Class DeserializeClass()
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Class obj = serializer.Deserialize<Class>(JSONSTRING);
                return obj;
            }
        }
                
