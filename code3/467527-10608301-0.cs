    public class StackOverflow_10608188
    {
        public static void Test()
        {
            string json = @"{""response"":{
              ""a"" : ""value of a"",
              ""b"" : ""value of b"",
              ""c"" : ""value of c""
            }}";
            JObject jo = JObject.Parse(json);
            foreach (JProperty property in jo["response"].Children())
            {
                Console.WriteLine(property.Value);
            }
        }
    }
