    private void MyMethod()
    {
    
      foreach (ReservedSimProjects item in parameters.ReservedProjects.ReservedSimProj)
      {
         SomeObj ProjDtl = new SomeObj(); //On the first iteration, ProjDtl might point to 0xabcdef,
         //on the second, 0x98765, on the third, 0xfedcba... but it will always be a new, unused memory address
    
         IQueryable<SJ> DbProj = SimColl.Where(e => e.SimProjectID == item.ProjectId);
    
         ProjDtl.ProjName = DbProj.First().ProjName; //Now, each iteration modifies a different
         ProjDtl.ProjArea = DbProj.First().ProjArea; //physical object
         ProjDtl.ProjPerim = DbProj.First().ProjArea;
         ....etc....
    
         ProjectsDetails.Add(ProjDtl);
      }
