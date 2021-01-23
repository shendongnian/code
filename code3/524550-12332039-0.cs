    public class MyResult
    {
        public string Title { get; set; }
    }
...
var result = client.Search<MyResult>(....)
