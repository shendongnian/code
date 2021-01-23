    var jsonObj = new JavaScriptSerializer().Deserialize<RootObj>(json);
    foreach (var obj in jsonObj.objectList)
    {
        Console.WriteLine(obj.address);
    }
    public class ObjectList
    {
        public string firstName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
    public class RootObj
    {
        public string objectType { get; set; }
        public List<ObjectList> objectList { get; set; }
    }
