    public static YourType FinalItem(IEnumerable<YourType> source)
    {
      YourType highest = default(YourType);
      int highestID = int.MinValue;
      foreach(YourType item in source)
      {
        curID = item.ID;
        if(highest == null || curID > highestID)
        {
          highest = item;
          highestID = curID;
        }
      }
      return highest;
    }
