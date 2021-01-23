    public class Employee
    {
         public Result ChangeEmployer(EmployerId id)
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
