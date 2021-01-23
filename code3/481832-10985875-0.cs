    using (MiscEntities pd = new MiscEntities())
    {
        Campground kc = pd.Campground.FirstOrDefault(i => i.Name == name);
        if (kc == null)
        {
            kc = new Campground();
            pd.Campground.Add(kc);          
        }
                
        kc.StreetAddress = streetAddress;
        kc.City = city;
        kc.State = state;
        kc.Zip = zip;
        kc.URL = campgroundUrl;
        kc.UpdatedDT = DateTime.Now;
        CampgroundEntities.Add(kc);
    }
