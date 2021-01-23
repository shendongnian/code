    public interface IPerson<TJob> where TJob : IJobRole
    {
      ICollection<TJob> JobRoles {get;set;} 
      void AddJobRole(TJob role);
    }
    
    public JobRole : IJobRole
    {
    }
    
    public class PersonViewModel:IPerson<JobRoles>
    {
      //collection is now part of the interface
      ICollection<JobRoles> JobRoles //= new List<JobRoles> in constructor
    
      public void AddJobRole(JobRoles role)
      {
        JobRoles.Add(role);
      }
    }
    
    public class PersonRepository
    {
       GetPerson(int id, IPerson<JobRoles> person)
       {
          //...
          foreach(var result...)
          {
            person.AddJobRole(new JobRole { 
                SomeProperty = //... 
                SomeOther = //...
            }
          }
       }
    }
