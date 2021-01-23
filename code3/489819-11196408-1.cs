    List<Project> projects;
    if (pick == null || pick == "active")
    {
        projects = db.usp_Train(idnbr).Where(a => a.Inactive == false).ToList();
    }
    else
    {
        projects = db.usp_Trainin(idnbr).ToList();
    }
    return PartialView(projects);
