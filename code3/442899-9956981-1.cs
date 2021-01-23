      public static bool IsPropertyExisting(dynamic settings, string name)
      {
        return settings.GetType().GetProperty(name) != null;
      }
      var settings = new {Filename = @"c:\temp\q.txt"};
      Console.WriteLine(IsPropertyExisting(settings, "Filename"));
      Console.WriteLine(IsPropertyExisting(settings, "Size"));
