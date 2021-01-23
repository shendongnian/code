    IQueryable<Train> proj = db.usp_Train(idnbr);
    if (pick == null || pick == "active")
    {
        proj = proj.Where(a => !a.Inactive);
    }
    return PartialView(proj.ToList());
