    public ACtionRestult GetProduct()
    {
       var model=new SomeModel();
       ViewBag.DateRange=GetSomeDataFromSomeWhereforDropDown();
       model.ReportType=3; //Assuming 3 is the value/ID  for `ThisMonthToDate` option
       return View(model);
    }
 
