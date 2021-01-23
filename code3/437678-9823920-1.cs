    public ActionResult GetItems()
    {
         details = Session["SelectedHeader"] as IHeader<IDetail>
         
         if (details != null)
         {
             // does it go into here?
             return Json(details. Details);
         }
    }
