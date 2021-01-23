    public class Parent
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int ParentID { get; set; }
    }
    
    var myObject = new Parent
    {
        Id = 1, 
        Text = "Some Text",
        ParentID = 4
    }
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string json = serializer.Serialize(myObject);
