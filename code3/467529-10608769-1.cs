    public class Blah
    {
        public ExpandoObject response = new ExpandoObject();
    }
    var json = "{\"response\":{\"a\":\"value of a\",\"b\":\"value of b\",\"c\":\"value of c\"}}";
    var x = new System.Web.Script.Serialization.JavaScriptSerializer();
    var res = x.Deserialize<IDictionary<string, IDictionary<string, string>>>(json);
    
    foreach (var key in res.Keys)
    {
        foreach (var subkey in res[key].Keys)
        {
            Console.WriteLine(res[key][subkey]);
        }
    }
