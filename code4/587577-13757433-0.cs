    foreach (var element in list)
    {
          foreach(Dictionary<string , string> itemList in element)
          {
            Response.Write( itemList["image"] );
          }
    }
