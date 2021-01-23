            public class Employee
            {
                [Key]
                public int EmployeeId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                // the rest..
                [ForeignKey("Office")]
                public int OfficeId { get; set; }
                [ForeignKey("EmployeeType")]
                public int EmployeeTypeId { get; set; }
                public virtual aspnet_Users User { get; set; }
                public virtual Office Office { get; set; }
            }
    public class EmployeeType
    { 
      [Key]
      public int EmployeeTypeId {get; set;}
      public string EmployeeTypeDescription {get; set;} // Doctor or whatever
    }
