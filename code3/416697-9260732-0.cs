    DataContext db = new DataContext(ConfigurationManager.AppSettings["myConnection"]);
    Table<RatesClass> CurrencyRatestbl = db.GetTable<RatesClass>();
    
    double Rate = 0.00;
    
    Rate = (from c in CurrencyRatestbl
            where c.From == "something"
            select Convert.ToDouble(c.Rate)).FirstOrDefault();
