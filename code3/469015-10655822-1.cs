    public class Details
    {
        public string state { get; set; }
        public List<Dictionary<string, string>> place { get; set; }
    }
    public class Wrap
    {
        public Details[] details { get; set; }
    }
    
    static void Main(string[] args)
    {
        string txt = File.ReadAllText("MyJSONFile.txt");
        JavaScriptSerializer ser = new JavaScriptSerializer();
        var data = ser.Deserialize<Wrap>(txt);
    }
