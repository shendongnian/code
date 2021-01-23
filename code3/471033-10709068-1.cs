    public ActionResult Create()
    {
        ViewBag.Projects = new List<SelectListItem>() { 
            new SelectListItem() 
            {
                Value = "1",
                Text = "Project 1",
                Selected = true
            }
        };
        //...
    }
