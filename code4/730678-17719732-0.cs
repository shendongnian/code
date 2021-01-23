    using System.Reflection;
    using System.Collections.Generic;
    public class Project { /* ... */ }
    
    public class ProjectSet
    {
      public Project Project1 { get; set; }
      public Project Project2 { get; set; }
    
      /* ... */
    
      public void AssignProjects(IList<Project> projects)
      {
        Type t = this.GetType();
    
        for (int i = 0; i < projects.Count; i++)
        {
          PropertyInfo p = t.GetProperty(string.Format("Project{0}", i + 1));
    
          if (p != null)
            p.SetValue(this, projects[i], null);    
        }
      }
    }
