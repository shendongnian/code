    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Description(string textdetails)
    {
        //Doing something with the text
        return RedirectToAction("Create", "Project", new { text = textdetails});
    }
