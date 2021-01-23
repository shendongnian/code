    public class Dependency
    {
         public string IssueId { get; set; }
         public string Status { get; set; }
         public int DependencyCheck { get; set; }
    }
    public class DependencyManager
    {
         public DependencyManager()
         {
              this.Dependencies = new List<Dependency>();
         }         
         public List<Dependency> Dependencies { get; private set; }
         public void AddDependency(string issueId)
         {
             var dep = new Dependency();
             dep.IssueId = issueId;
             dep.Status = "open";
             dep.DependencyCheck = 0;
             
             this.Dependencies.Add(dep);
         }
         public void SetDependencyCheck(string issueId, int value)
         {
             var dep = this.FindDependencyByIssueId(issueId);
             dep.DependencyCheck = value;
         }
         public Dependency FindDependencyByIssueId(string issueId)
         {
             var dep = this.Dependencies.FirstOrDefault(d => d.IssueId.Equals(issueId));
             if(dep == null) throw new ArgumentException("Dependency not found", "issueId");
             return dep;
         }
    }
