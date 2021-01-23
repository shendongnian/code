    [HttpPost]
    public ActionResult CheckData(string btnSearch)
    {
        if (btnSearch == "Yes") {
            // The Yes submit button was clicked
        } else if (btnSearch == "No") {
            // The No submit button was clicked
        }
        return RedirectToRoute("detailform");
    }
