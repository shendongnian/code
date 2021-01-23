    public ActionResult Add_CRM_Invoice()
    {
      Invoice model = new Invoice();
      if (Request.IsAjaxRequest())
      {
        return PartialView("_Add_Invoice_Detail",model);
      }
      else
      {
        return View("Add_CRM_Invoice",model);
      }
    }
