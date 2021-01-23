    Dictionary<int, List<Controller>> dict = new Dictionary<int, List<Controller>>();
         
    int x = 0;
    int dictKey = 0;
    while (x < controllerList.Count)
    {
       List<Controller> newList = new List<Controller>
          { controllerList[x++] };
       if (x < controllerList.Count)
          newList.Add(controllerList[x++]);
       if (x < controllerList.Count)
          newList.Add(controllerList[x++]);
       dict.Add(dictKey++, newList);
    }
