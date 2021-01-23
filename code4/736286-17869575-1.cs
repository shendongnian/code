    public void myMethod()
    {
        string myContent = @"
            [
                {
                    ""json_content"": {
                        ""city"": ""city 1"", 
                        ""myAge"": 15
                    }
                },
                {
                    ""json_content"": {
                        ""city"": ""city 2"", 
                        ""myAge"": 18
                    }
                }
            ]";
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<holder> list = serializer.Deserialize<List<holder>>(myContent);
    }
    public class holder
    {
        public json_content json_content { get; set; }
    }
    public class json_content
    {
        public string city { get; set; }
        public int myAge { get; set; }
    }
