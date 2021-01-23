    [HttpPost()]
    public ActionResult DisplaySections(string id)
    {
        DataContext db = new DataContext();
    
        List<string> data = 
            (from p in db.vwData.Where(a => a.CourseId == id)
             group p by p.SectionId into g
             select g.Key).ToList();
    
        return PartialView("DisplaySections", data);
    }
