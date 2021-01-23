    [WebMethod]
    public static void UpdateMethod(string projectname, string projectdesc)
    {
      Project Proj1 = new Project();
      Project.ProjectName=projectname;
      Project.ProjectDesc = projectdesc;
    }
    public class Project
    {
      public string ProjectName{get;set;}
      public string ProjectDesc{get;set;]
    }
