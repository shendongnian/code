    var list = new JavaScriptSerializer().Deserialize<List<ROOT>>(json);
    public class RESULT
    {
        public List<string> TYPES { get; set; }
        public List<string> HEADER { get; set; }
        public List<List<string>> ROWS { get; set; }
    }
    public class ROOT
    {
        public RESULT RESULT { get; set; }
    }
