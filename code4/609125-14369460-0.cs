    var obj = new JavaScriptSerializer().Deserialize<Root>(jsonstring);
--
    public class Root
    {
        public Dictionary<string,List<VersionAddress>> addresses;
        //Your other fields/properties
    }
    public class VersionAddress
    {
        public string version;
        public string address;
    }
