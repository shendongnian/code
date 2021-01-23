    class Item {
        public string status { get; set; }
        public string classkey { get; set; }
    }
    var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
    var input = "{\"pometek.net\":{\"status\":\"available\",\"classkey\":\"dotnet\"},\"pometek.com\":{\"status\":\"available\",\"classkey\":\"domcno\"}}";
    var results = jss.Deserialize<Dictionary<string, Item>(input);
    var query = results["pometek.net"].status; // = "available"
