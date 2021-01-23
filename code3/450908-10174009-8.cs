    var query = Modules.GroupBy(m => m.ModuleValue)
        .Select(g => new { ModuleValue = g.Key, Values = g });
    Func<Module, bool> matchy2013 = m => m.Year == 2013;
    Func<Module, bool> matchy2014 = m => m.Year == 2014;
    Func<Module, bool> matchy2015 = m => m.Year == 2015;
    Func<Module, bool> matchy2016 = m => m.Year == 2016;
    IList<NewModule> PivotedModules = new List<NewModule>();
    foreach (var item in query)
    {
        var xrateRow = new NewModule
        {
            ModuleValue = item.ModuleValue,
             ValueType = "xrate",
             y2013 = item.Values.Where(matchy2013).FirstOrDefault().xrate,
             y2014 = item.Values.Where(matchy2014).FirstOrDefault().xrate,
             y2015 = item.Values.Where(matchy2015).FirstOrDefault().xrate,
             y2016 = item.Values.Where(matchy2016).FirstOrDefault().xrate
         };
         var yrateRow = new NewModule
         {
             ModuleValue = item.ModuleValue,
             ValueType = "yrate",
             y2013 = item.Values.Where(matchy2013).FirstOrDefault().yrate,
             y2014 = item.Values.Where(matchy2014).FirstOrDefault().yrate,
             y2015 = item.Values.Where(matchy2015).FirstOrDefault().yrate,
             y2016 = item.Values.Where(matchy2016).FirstOrDefault().yrate
          };
          var cumrateRow = new NewModule
          {
              ModuleValue = item.ModuleValue,
              ValueType = "cumrate",
              y2013 = item.Values.Where(matchy2013).FirstOrDefault().cumrate,
              y2014 = item.Values.Where(matchy2014).FirstOrDefault().cumrate,
              y2015 = item.Values.Where(matchy2015).FirstOrDefault().cumrate,
              y2016 = item.Values.Where(matchy2016).FirstOrDefault().cumrate
           };
           PivotedModules.Add(xrateRow);
           PivotedModules.Add(yrateRow);
           PivotedModules.Add(cumrateRow);
    }
