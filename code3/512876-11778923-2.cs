    public int Option(string arg)
    {
      var foundItem = 
          EnumHelper.list_of_t.SingleOrDefault(c => c.GetEnumDescription() == arg);
      if (foundItem != null)
      {
        return (int)foundItem;
      }
      else
      {
        return 0;
      }
    }
