    from p in db.Projects
    join d in db.Documents on new { ProjectID = p.ProjectID } 
                       equals new { ProjectID = Convert.ToInt32(d.ProjectID) }
    select new { p, d,
                 LastRevision = db.Revisions
                     .Where(r => d.DocumentID = Convert.ToInt32(r.DocumentID))
                     .OrderByDescending(r => r.RevisionId)
                     .FirstOrDefault() }
