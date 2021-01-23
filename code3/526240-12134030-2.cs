    foreach(var group in profiles)
    {
      Console.WriteLine("The user is :" + group.Key.UserName + " (id: " + group.Key.UserID ")");
      foreach(var item in group)
      {
        Console.WriteLine(item.SomeThing + " was rated " + item.RatingValue);
      }
    }
