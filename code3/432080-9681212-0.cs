    public class MyFacebookClass
    {
        public MyFacebookClass()
        {
            data = new List<CustomObject>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public List<CustomObject> data { get; set; }
    }
    public class CustomObject
    {
        public CustomObject()
        {
            /*  now you have a constructor */
        }
        public string id { get; set; }
        public string name { get; set; }
    }
    public class Main
    {
        public List<MyFacebookClass> Deserialize(string json)
        {
            List<MyFacebookClass> routes_list = new List<MyFacebookClass>();
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            return jSerializer.Deserialize<List<MyFacebookClass>>(json); 
        }
    }
