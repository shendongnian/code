    public ScreenDto[] GetData(DateTime d)
       {
           ScreenScrapingEntities1 db = new ScreenScrapingEntities1();
           ScreenDto[] sd = (from p in db.Screen_Data
                                where p.DateTime > d
                                select new ScreenDto()
                                {Id = p.Id, Name = p.Name, DateAdded =p.Date)
                                .ToArray();
           return sd; // put break point here, to check return data
        }
