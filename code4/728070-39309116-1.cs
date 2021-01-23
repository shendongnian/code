    [ChildActionOnly]
    public ActionResult Results() 
    {
        EnumerableRowCollection<DataRow> custs = ViewBag.Customers;
        bool anyRows = custs.Any();
        if(anyRows == false)
        {
            return View("NoResults");
        }
        else
        {
            return View("OtherView");
        }
    }
