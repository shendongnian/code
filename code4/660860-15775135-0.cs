    private void MyMethod()
    {
      SomeObj ProjDtl = null;
    
    
      foreach (ReservedSimProjects item in parameters.ReservedProjects.ReservedSimProj)
      {
         ProjDtl = new SomeObj()
         IQueryable<SJ> DbProj = SimColl.Where(e => e.SimProjectID == item.ProjectId);
    
         ProjDtl.ProjName = DbProj.First().ProjName;
         ProjDtl.ProjArea = DbProj.First().ProjArea;
         ProjDtl.ProjPerim = DbProj.First().ProjArea;
         ....etc....
    
         ProjectsDetails.Add(ProjDtl);
      }
