    public static List<Project> Index(this List<Project> list, params int[] indexes) 
    {
      var newList = new List<Project>();
      foreach(var index in indexes)
      {
         newList.Add(list[index]);
      }
      return newList;
    }
