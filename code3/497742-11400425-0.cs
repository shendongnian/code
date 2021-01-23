    [HttpPost]
    public ActionResult DoMath(int yourArguments)
    {
        System.Data.DataTable yourTabularResults = new System.Data.DataTable();
        //your magic
        return View(yourTabularResults);
    }
