    using System.Web.Script.Serialization;
    var jss = new JavaScriptSerializer();
    var dict = jss.Deserialize<Dictionary<string, string>>(jsonText);
    NameValueCollection nvc = null;
    if (dict != null) {
      nvc = new NameValueCollection(dict.Count);
      foreach (var k in dict) {
        nvc.Add(k.Key, k.Value);
      }
    }
                        }
    var json = jss.Serialize(dict);
    Console.WriteLine(json);
