    string itemListKey = "itemListKey";
    List<string> itemList
    {
      get
      {
         if ( Session[itemListKey] == null )
            Session[itemListKey] = new List<string>();
         return (List<string>)Session[itemListKey];
      }
    }
