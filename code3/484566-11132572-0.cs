    public class Employee
    {
       public virtual long Id {get; private set;}
       public virtual string FirstName {get;set;}
       public virtual string LastName {get;set;}
       public virtual Employee Manager {get;set;}
       public virtual ICollection<Employee> ManagedEmployees {get; private set;}
    }
    
    public class EmployeeMap : MapClass<Employee>
    {
       Table("TEmployee");
       SchemaAction.None();
       Id(e => e.Id).GeneratedBy.HiLow("1000");
       References(e => e.Manager, "ManagerId");
       HasMany(e => e.Manager).KeyColumn("ManagerId").Cascade.All();
    }
