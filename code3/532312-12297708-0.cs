    public IEnumerable<SelectListItem> Functions { get
    {
        using (followupconsultantEntities dataModel = new followupconsultantEntities())
        {
            return new SelectList(dataModel.functions.Select(f=>
                   new 
                   {
                       Value = function.ID_Function.ToString(CultureInfo.InvariantCulture),
                       Text = function.FU_Name
                   })
                   .ToArray(), "ID_Function", "FU_Name");
       }
   }
