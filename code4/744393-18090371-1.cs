    [HttpPost]
    public ActionResult SomeAction(MyViewModel model, string btn)
    {
        if (btn == "search")
        {
            // The search button was clicked, so do whatever you were doing 
            // in your Search controller action
        }
        else if (btn == "export") 
        {
            // The "Export to Spreadsheet" button was clicked so do whatever you were
            // doing in the controller action bound to your ActionLink previously
        }
        ...
    }
