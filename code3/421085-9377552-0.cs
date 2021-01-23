    using System;
    using System.Net;
    using System.Web.Script.Serialization;
    
    public class YahooResponse
    {
        public Query Query { get; set; }
    }
    
    public class Query
    {
        public Results Results { get; set; }
    }
    
    public class Results
    {
        public Result[] Result { get; set; }
    }
    
    public class Result
    {
        public string Title { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20local.search%20where%20query%3D%22sushi%22%20and%20location%3D%22san%20francisco%2C%20ca%22&format=json&diagnostics=true")
                var jss = new JavaScriptSerializer();
                var result = jss.Deserialize<YahooResponse>(json);
                foreach (var item in result.Query.Results.Result)
                {
                    Console.WriteLine(item.Title);
                }
    
            }
        }
    }
