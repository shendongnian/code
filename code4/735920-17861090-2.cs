    using (MyEntities context = new MyEntities ())
    {
        var qry = from col in context.vwSystemProperties
                  select new
                      {
                          SystemPropertyName = col.SystemPropertyName,
                          SystemPropertyEnumVal = col.SystemPropertyEnumVal,
                          SystemPropertyValue = col.SystemPropertyValue,
                          ApplicationScope = col.ApplicationScope,
                          CategoryScope = col.CategoryScope,
                          EntityScope = col.EntityScope,
                          VersionDate = col.VersionDate,
                          VersionUser = col.VersionUser
                      };
        BindingSource bs = new BindingSource();
        bs.DataSource = qry.ToList();
        SystemPropertyDGV.DataSource = bs;
    }
