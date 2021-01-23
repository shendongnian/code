      public static bool IsPropertyExisting(dynamic settings, string name)
      {
        return settings.GetType().GetProperty(name) != null;
      }
      var settings = new {Filename = @"c:\temp\q.txt"};
      Console.WriteLine(DoesPropertyExist(settings, "Filename"));
      Console.WriteLine(DoesPropertyExist(settings, "Size"));
