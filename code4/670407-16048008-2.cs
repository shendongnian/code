    [HttpGet]
    public virtual ActionResult LoadTableReporteGeneral(string viewModel)
    {
        var filterOptions = JsonConvert.DeserializeObject<FilterViewModel>(viewModel);
        var query = from t in db.YourTableName
                    select t;
         //This returns an IQueryable with all of your data, no filtering yet.
         //Start filtering.
         if(!String.IsNullOrEmpty(filterOptions.ObjName))
         {
             query = query.Where(x => x.ObjName == filterOptions.ObjName);
         }  
         if(!String.IsNullOrEmpty(filterOptions.ObjType ))
         {
             query = query.Where(x => x.ObjType == filterOptions.ObjType );
         }  
         //and so on. 
         //Finally return a partial view with your table. 
         return PartialView(MVC.Shared.Views._YourTableName, query);
    }
