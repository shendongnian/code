      public static bool IsPropertyExist(dynamic settings, string name)
      {
        return settings.GetType().GetProperty(name) != null;
      }
      var settings = new {Filename = @"c:\temp\q.txt"};
      Console.WriteLine(IsPropertyExist(settings, "Filename"));
      Console.WriteLine(IsPropertyExist(settings, "Size"));
