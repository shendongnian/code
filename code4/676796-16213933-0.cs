    public ActionResult MyResults(DataTablePrameters param = null) {
        if(string.IsNullOrEmpty(param.sEcho) && string.IsNullOrEmpty(param.iDisplayStart) && string.IsNullOrEmpty(param.iDisplayLength))
            return PartialView();
        
    //Do something
    
    return Json(...);
    }
