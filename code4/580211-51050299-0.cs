    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    public List<string> GetJsonValues(string filePath, string propertyName)
    {
      List<string> values = new List<string>();
      string read = string.Empty;
      using (StreamReader r = new StreamReader(filePath))
      {
        var json = r.ReadToEnd();
        var jObj = JObject.Parse(json);
        foreach (var j in jObj.Properties())
        {
          if (j.Name.Equals(propertyName))
          {
            var value = jObj[j.Name] as JArray;
            return values = value.ToObject<List<string>>();
          }
        }
        return values;
      }
    }
