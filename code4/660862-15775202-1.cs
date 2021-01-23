    SomeObj ProjDtl = new SomeObj(); //now ProjDtl points to 0xabcdef
    foreach (ReservedSimProjects item in parameters.ReservedProjects.ReservedSimProj)
      {
         IQueryable<SJ> DbProj = SimColl.Where(e => e.SimProjectID == item.ProjectId);
    
         ProjDtl.ProjName = DbProj.First().ProjName; //Since ProjDtl is never overwritten,
         ProjDtl.ProjArea = DbProj.First().ProjArea; //it will always point to 0xabcdef,
         ProjDtl.ProjPerim = DbProj.First().ProjArea; //and you're always accessing the same physical object's data
         ....etc....
    
         ProjectsDetails.Add(ProjDtl);
      }
