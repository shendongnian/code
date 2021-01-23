    public ActionResult DisplayForm(int? documentId, long status)
            {
                ViewBag.Status = status;
                return View(GetSortedFieldsForDocument(documentId));
            }
