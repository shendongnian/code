    public class Employee
    {
         private EmployerId employerId;
         public Employee(EmployerId id /* other params such as name etc */)
         {
             var employerSetResult = this.SetEmployerId(id);
             if(!result.Success)
                throw new ArgumentException("id", "id is invalid");
         }
         // this is a separate method because you will need to set employerId
         // from multiple locations and should only ever call SetEmployerId 
         // internally
         public Result ChangeEmployer(EmployerId id)
         {
              var result = this.SetEmployerId(id);
              if(result.Success)
                 DomainEventPublisher.Publish(
                   new EmployeeEmployerChanged(id, this.id));
              return result;
         }
         private Result SetEmployerId(Employer id)
         {
              var result = EmployerIdValidator.Validate(id);
              if(result.Success)
                 this.employerId = id;
              return result;
         }
    }
    public static class EmployerIdValidator
    {
        public static Result Validate(EmployerId id)
        {
            if(id < 5)
               return new Result(success: false, new ValidationResult("Id too low"));
            else if (id > 10)
               return new Result(success: false, new ValidationResult("Id too high"));
            return new Result(success:true);
        }
    }
    public class Result
    {
         public bool Success {get {return this.success;}}
         public IEnumerable<ValidationResult> ValidationResults 
         { 
            get{ return this.validationResults; }
         } 
    }
