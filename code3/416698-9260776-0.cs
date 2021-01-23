    using(DataContext db = new DataContext(ConfigurationManager.AppSettings["myConnection"]))
    {
    	var rate=db.GetTable<RatesClass>()
                 .Where(a=>a.From == "something")
                 .Select(a=>Convert.ToDouble(a.Rate))
                 .SingleOrDefault();
    }
