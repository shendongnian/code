    var proj = db.usp_Train(idnbr);
    
    if (pick == null || pick == "active")
        proj = proj.Where(a => a.Inactive == false);
    return PartialView(proj.ToList());    
