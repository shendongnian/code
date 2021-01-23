    IQueryable<Test> tests = null;
    // some other assignment to tests
    tests = db.Tests.Where
            (t => t.OAS_Group.Candidates.All
                 (c=>c.UserName == HttpContext.User.Identity.Name)
            ); 
