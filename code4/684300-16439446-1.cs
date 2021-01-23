    IQueryable<MyQueryResult> query = null; //This is now possible
    //select the Table to query
    switch (FolderName)
    {
        case "NewsManager":
            query = from q in db.News Where q.ID == itemID 
                     select new MyQueryResult
                     {
                         isSpotLight=q.Something,
                         thumbPath = q.SomethingElse
                         etc...
                      }
            break;
        case "ProductsManager":
            query = (from q in db.Products Where ...
                     select new MyQueryResult
                     {
                         ---fill properties
                     }
            break;
         .... same thing for every case
      }
      
      var uniqueItm = query.FirstOrDefault();
      if (uniqueItm!=null)
      {
          ... do your thing with uniqueItm
      } 
