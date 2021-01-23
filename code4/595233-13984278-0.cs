    static Dictionary<string,object> Parse(string contents)
    {
       var root = new Dictionary<string,object>();
       
       using (var rdr = new StringReader(contents))
       {
          string line;
          var equals = new [] {'='};
          while(null != (line = rdr.ReadLine()))
          {
             if(!string.IsNullOrEmpty(line))
             {
                var keyValue = line.Split(equals, 2);
                AddValue(root, keyValue[0], keyValue[1]);
             }
          }
       }
    
       return root;
    }
    
    static void AddValue(Dictionary<string,object> dict, string dottedKeys, string value)
    {
       string [] keys = dottedKeys.Split('.');
       for(var i = 0; i < keys.Length - 1; i++)
       {
          var key = keys[i];
          dict = GetOrAdd(dict, key);
       }
       dict[keys[keys.Length - 1]] = value;
    }
    
    static Dictionary<string,object> GetOrAdd(Dictionary<string,object> parent, string key)
    {
       object o;
       Dictionary<string,object> childDict;
       if(parent.TryGetValue(key, out o))
          childDict = (Dictionary<string,object>) o;  // This will throw when adding a dictionary to a value.
       else
          parent[key] = childDict = new Dictionary<string,object>();
       return childDict;
    }
    
    static string fileContents=@"
    tabs.main=""******""
    tabs.settings=""******""
    
    settings.setting1=""******""
    settings.setting2=""******""
    settings.setting3=""******""
    settings.setting4=""******""
    settings.setting5=""******""
    
    settings.setting6.settingoption1=""******""
    settings.setting6.settingoption2=""******""
    ";
