    public class JavascriptSerializer : ISerializer
    {
        public string Serialize(Data data)
        {
            return data.Content; //whatever you want do instead for serialization
        }
    }
