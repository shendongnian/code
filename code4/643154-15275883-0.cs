    public ActionResult DivisionSwitch(int abbreviation)
    {
        var newdivision = from f in db.Divisions
                          where f.DepartmentKey == abbreviation
                          select f;
        return Json(newdivision);
    }
    public ActionResult SectionSwitch(int abbreviation)
    {
        var newsection = (from t in db.Sections
                          where t.DivisionKey == abbreviation
                          select new sectionInfo { sectionNum = t.SectionKey, sectionname = t.SectionDesciption });
        return Json(newsection);
    }
