    try
    {
        using (var rep = new Repository<Profile>())
                    {
                        var vals = rep.FindWhere(p => p.ProjectID == projectID)
                                      .OrderBy(p => p.Name)
                                      .Select(
                                          s => new
                                              {
                                                  s.ID,
                                                  s.Name
                                              }).ToList();
                        return Json(vals, JsonRequestBehavior.AllowGet);
                    }
    } 
    catch(Exception ex)
    {
       // use ex here
       ErrorLog.Add(ex);
       // return whatever makes sense for you clientside
       return Json(false, JsonRequestBehavior.AllowGet);
       // or just throw exception and use error callback in js
       throw;
    }
