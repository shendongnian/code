    public ActionResult UpdateConfirmation()
         {
           if (TempData["doc"] != null)
            {
                XDocument updatedResultsDocument = (XDocument) TempData["doc"];
                ...
                return View();
            }
         }
