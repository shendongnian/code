    using System.Web.Script.Serialization;
    var jss = new JavaScriptSerializer();
    var dict = jss.Deserialize<NameValueCollection>(jsonText);
    var json = jss.Serialize(dict);
    Console.WriteLine(json);
