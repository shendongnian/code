    public IEnumerable<SelectListItem> Functions { get
    {
        using (followupconsultantEntities dataModel = new followupconsultantEntities())
        {
            return new SelectList(dataModel.functions.ToArray(), "ID_Function", "FU_Name");
        }
    }
