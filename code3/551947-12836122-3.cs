    [HttpPost]
    public ActionResult CheckData(string btnSearch)
    {
        if (btnSearch == "yes") {
            // The Yes submit button was clicked
        } else if (btnSearch == "no") {
            // The No submit button was clicked
        }
        return RedirectToRoute("detailform");
    }
