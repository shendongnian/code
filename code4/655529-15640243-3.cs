    public ActionResult Index(int? filterTheme, int? selectedStyle)
    {
        var projects = from s in db.Project select s;
    
        if (filterTheme != null)
        {
            projects = from s in db.Project
                       from c in s.Themes
                       where c.ThemeID == filterTheme.Value
                       select s;             
        }
    
        if (selectedStyle != null)
        {
            projects = from s in projects
                       from c in s.Style
                       where s.ID == selectedStyle.Value
                       select s;
        }
    
        ViewData["Theme"] = new SelectList(db.Theme.ToList(), "ThemeID", "Name");
        ViewData["Styles"] = new SelectList(db.Project.ToList(), "ID", "Style");
    
        return View(projects);
    }
