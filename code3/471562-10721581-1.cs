    List<IMachines> list = new List<IMachines>();
    list.Add(new AC());
    list.Add(new Generator());
    foreach(IMachines o in list)
    {
      if (o is Ingredient)
      {
        //do sth
      }
      else if (o is Drink)
      {
        //do sth
      }
    }
