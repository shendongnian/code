    [TestClass]
    public class FbRequestParserTests
    {
        [TestMethod]
        public void ParseFacebookResponse()
        {
            var response =
                @"{
                  ""id"": ""123123"",
                  ""name"": ""My name"",
                  ""picture"": {
                                ""data"": {
                                    ""is_silhouette"": false,
                                    ""url"": ""https://scontent.xx.fbcdn.net/v/t1.0-1/p50x50/14572785_123""
                                }
                            },
                  ""friends"": {
                    ""data"": [
                        {
                        ""name"": ""Friend 1"",
                        ""id"": ""123""
                      },
                      {
                        ""name"": ""Friend 2"",
                        ""id"": ""234""
                      }
                    ],
                    ""paging"": {
                      ""cursors"": {
                        ""before"": ""QVFIUk1yRE9zTkhFdkc1TFV2SHVpaE1IYUJ4V2ljbUJSbjYxaGhnX05IcTNYWHp0ekNHZAnh6LThs"",
                        ""after"": ""QVFIUjFFQW5kVmJiTmMxZAHN6cWNDdUl5VnVJVl91UG0yV2hMOVl5N21GTDVxQ2JVQ2hjQVlRYXBxNDNkWWI3YjZAkZAFBV""
                      }
                    },
                    ""summary"": {
                      ""total_count"": 456
                    }
                  }
                }";
            var result = JsonConvert.DeserializeObject<FbResponse>(response);
            Assert.AreEqual(result.Id, 123123);
            Assert.AreEqual(result.Name, "My Name");
        }
    }
    public class FbResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Picture Picture { get; set; }
        public Friends Friends { get; set; }
    }
    public class Friends
    {
        public List<FriendsData> Data { get; set; }
        public Paging Paging { get; set; }
        public Summary Summary { get; set; }
    }
    public class Summary
    {
        public int Total_Count { get; set; }
    }
    public class Paging
    {
        public Cursors Cursors { get; set; }
    }
    public class Cursors
    {
        public string Before { get; set; }
        public string After { get; set; }
    }
    public class FriendsData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Picture
    {
        public PictureData Data { get; set; }
    }
    public class PictureData
    {
        public bool Is_Silhouette { get; set; }
        public string Url { get; set; }
    }
