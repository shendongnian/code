    public class Item
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Item SubItem { get; set; }
    }
    
    var myObject = new Item
    {
        Id = 1, 
        Text = "Some Text",
        SubItem = new Item { Id = 2, Text = "SubItem" }
    }
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string json = serializer.Serialize(myObject);
