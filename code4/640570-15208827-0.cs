    private bool ValidateDept(OnlineFormsEntities context, Department dept, out string errorMessage)
    {
      errorMessage = string.empty;
      
      if (context.Departments.Any(d => d.DepartmentName.ToLower() == dept.DepartmentName.ToLower()))
       {
         errorMessage = "A Department with the given name already exists.";
         return false;
       }
     if (context.Departments.Any(d => d.Transit.ToLower() == dept.Transit.ToLower()))
       {
         errorMessage = "A Department with the given Transit # already exists.";
         return false;
      }
     return true;
    }
