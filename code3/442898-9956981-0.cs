      public static bool IsSettingsExist(dynamic settings, string name)
      {
        return settings.GetType().GetProperty(name) != null;
      }
      var settings = new {Filename = @"c:\temp\q.txt"};
      Console.WriteLine(IsSettingsExist(settings, "Filename"));
      Console.WriteLine(IsSettingsExist(settings, "Size"));
