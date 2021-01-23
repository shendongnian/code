    public class StackOverflow_11439028
    {
        public class MyType
        {
            public string name { get; set; }
            public string call { get; set; }
        }
        const string Json = @"{ ""item a"": [ { ""name"": ""alpha"", ""call"": ""a"" } ],
                                ""item b"": [],
                                ""item c"": [ 
                                    { ""name"" : ""beta"" , ""call"" : ""b"" }, 
                                    { ""name"" : ""gamma"",  ""call"" : ""g"" },
                                    { ""name"" : ""alpha"",  ""call"" : ""a"" }
                                ]
                            }";
        public static void Test()
        {
            JsonSerializer js = new JsonSerializer();
            using (JsonTextReader jtr = new JsonTextReader(new StringReader(Json)))
            {
                var obj = js.Deserialize<Dictionary<string, List<MyType>>>(jtr);
                Console.WriteLine(obj);
            }
        }
    }
