      public static bool IsPropertyExist(dynamic settings, string name)
      {
        if (settings is ExpandoObject)
          return ((IDictionary<string, object>)settings).ContainsKey(name);
        return settings.GetType().GetProperty(name) != null;
      }
      var settings = new {Filename = @"c:\temp\q.txt"};
      Console.WriteLine(IsPropertyExist(settings, "Filename"));
      Console.WriteLine(IsPropertyExist(settings, "Size"));
