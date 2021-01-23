    public ActionResult MyResults(DataTablePrameters param = null) {
      if(param == null)
        return PartialView();
      
      // Repository action...
      
      return Json([...]);
    }
