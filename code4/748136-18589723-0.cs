    Classes generated from your JSON data:
    <pre>
    
        public class Result
        {
            public List&ltstring&gt sample1 { get; set; }
            public string sample2 { get; set; }
        }
    
        public class Datum
        {
            public int key { get; set; }
            public Result result { get; set; }
        }
    
        public class RootObject
        {
            public string serverTime { get; set; }
            public List&ltDatum&gt data { get; set; }
        }
    
    </pre>
    User Newtonsoft.Json dll to Deserialize JSON data like:
    <pre>
    
        var obj = JsonConvert.DeserializeObject&ltRootObject&gt("yourjsonstring");
    
    </pre>
    then you can use properties of obj like:
    <pre>
    
        var date = DateTime.Parse(obj.serverTime);
    
    </pre>
    and so on.
