    [HttpPost]
    public ActionResult ItemSubmissionForm(CombinedModelContent membervalues)
    { ...
        ItemSubmissionsDBFields aFieldsList = membervalues.FieldsList;  //Stripping other objects
        return RedirectToAction("ItemSubmissionConfirm", aFieldsList);
    }
    [HttpGet]
    public ActionResult ItemSubmissionConfirm(ItemSubmissionsDBFields aFieldsList)
    { ...
       List<SomeArea> SomeAreaitems = new List<SomeArea>();
       SomeAreaitems.Add  ...
       CombinedModelContent copymembervalues = new CombinedModelContent();
            copymembervalues.SomeCodeLists = SomeAreaitems;
            copymembervalues.FieldsList = aFieldsList;  
       return View("SomeConfirmPage", copymembervalues);
