    public List<SomeData> Updater(DateTime clientSideLastUpdate)
    {
         List<SomeData> news = new List<SomeData>();
         while(true)
         {
             List<SomeData> news = dbContext.SomeData.Where(e=>e.UpdateDateTime > clientSideLastUpdate).ToList();
             if(news.Count()>0)
             {
                 return news;
             }
         }
    }
