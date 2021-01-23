    public class Item
    {
        public int Id { get; set; }
        public int MsgId { get; set; }
        public string ExceptionDetails { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> Items { get; set; }
        public RootObject DeserializeClass()
        {
             JavaScriptSerializer serializer = new JavaScriptSerializer();
             RootObject obj = serializer.Deserialize<RootObject >(JSONSTRING);
             return obj;
         }
    }
                
