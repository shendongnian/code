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
            Func<List<MyType>, string> listToString = l =>
                "[" + string.Join(", ", l.Select(t => string.Format("{0}-{1}", t.call, t.name))) + "]";
            using (JsonTextReader jtr = new JsonTextReader(new StringReader(Json)))
            {
                var obj = js.Deserialize<Dictionary<string, List<MyType>>>(jtr);
                Console.WriteLine(string.Join(", ", obj.Select(kvp => string.Format("{{{0}, {1}}}", kvp.Key, listToString(kvp.Value)))));
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, List<MyType>>>(Json);
            Console.WriteLine(string.Join(", ", dict.Select(kvp => string.Format("{{{0}, {1}}}", kvp.Key, listToString(kvp.Value)))));
        }
    }
