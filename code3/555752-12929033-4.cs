    // System.Web.Extensions.dll
    using System.Web.Script.Serialization;
    var result = new JavaScriptSerializer().Deserialize<Result>(jsonString);
    public class Result
    {
        public int status;
        public List<Item> data;
    }
    public class Item
    {
        public string report_date;
        public string subid;
        public string revenue;
        public string clicks;
    }
