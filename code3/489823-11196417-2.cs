    // Or whatever the type is...
    List<Train> proj;
    if (pick == null || pick == "active")
    {
        proj = db.usp_Train(idnbr)
                 .Where(a => a.Inactive == false).ToList();
    }        
    else 
    {
        proj = db.usp_Train(idnbr).ToList();
    }
    return PartialView(proj);
