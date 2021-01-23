      dynamic obj = JsonConvert.DeserializeObject(json);      
      foreach (dynamic item in obj as System.Collections.IEnumerable)
      {
        var c = (ColorEntry)obj[item.Name].ToObject(typeof(ColorEntry));
        c.Id = int.Parse(item.Name);
      }
