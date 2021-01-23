    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    static class Program
    {
        static void Main()
        {
            // here imagine we're in the web tier, serializing
            var data = GetData();
            var jsonData = JsonConvert.SerializeObject(
                data.ToArray(), Formatting.None);
            // now imagine we're at the application, deserializing
            var appData = JsonConvert.DeserializeObject<Application.MyModel[]>(
                jsonData);
            // and it all works fine
        }
        static IEnumerable<WebSolution.MyModel> GetData()
        {
            yield return new WebSolution.MyModel { Id = 123, Name = "abc" };
            yield return new WebSolution.MyModel { Id = 456, Name = "def" };
        }
    }
    
    namespace WebSolution
    {
        // MyModel
        public class MyModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
    
    namespace Application
    {
        // MyModel
        public class MyModel
        {
            [JsonProperty("Id")]
            public long Id { get; set; }
            [JsonProperty("Name")]
            public string Name { get; set; }
        }
    }
