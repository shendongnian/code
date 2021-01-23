    public int Option(string arg)
    {
      // get the matching enum for the "/t:" switch here.
      var foundItem = 
          EnumHelper.list_of_t.SingleOrDefault(c => c.GetEnumDescription() == arg);
      if (foundItem != null)
      {
        return (int)foundItem;  // <<-- this will return 0, 1000, or 2000 in this example.
      }
      else
      {
        return 0;
      }
    }
