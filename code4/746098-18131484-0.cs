    [Test]
    public void Json()
    {
             var input = @"{
       ""Description"":""test"",
       ""RoomTypes"":[
          {
             ""Key"":""A"",
             ""Value"":{
                ""Name"":""Delux""
             }
          },
          {
             ""Key"":""B"",
             ""Value"":{
                ""Name"":""Non delux""
             }
          }
       ],
       ""Url"":""http:\/\/test.com""
    }";
    
        var temp = JsonConvert.DeserializeObject<Temp>(input);
        var transform = new Transform
            {
                Description = temp.Description,
                Url = temp.Url,
                RoomTypes = new List<IDictionary<string, Temp.NameObj>>()
            };
    
        foreach (var group in temp.RoomTypes)
        {
            var dic = new Dictionary<string, Temp.NameObj> {{@group.Key, @group.Value}};
            transform.RoomTypes.Add(dic);
        }
    
        Console.WriteLine(JsonConvert.SerializeObject(transform));
    }
    
    public class Transform
    {
        public string Description { get; set; }
        public IList<IDictionary<string, Temp.NameObj>> RoomTypes { get; set; }
        public string Url { get; set; }
    }
        
        
    public class Temp
    {
        public string Description { get; set; }
        public IList<GroupObj> RoomTypes { get; set; }
        public string Url { get; set; }
    
        public class GroupObj
        {
            public string Key { get; set; }
            public NameObj Value { get; set; }
        }
    
        public class NameObj
        {
            public string Name { get; set; }
        }
    }    
