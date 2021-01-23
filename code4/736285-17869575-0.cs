    public static void myMethod()
    {
        string myContent = @"
            [
                {
                    ""city"": ""city 1"", 
                    ""myAge"": 15
                },
                {
                    ""city"": ""city 2"", 
                    ""myAge"": 18
                }
            ]";
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<json_content> list = serializer.Deserialize<List<json_content>>(myContent);
    }
    public class json_content
    {
        public string city { get; set; }
        public int myAge { get; set; }
    }
