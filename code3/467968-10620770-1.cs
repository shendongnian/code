    var result = (from c in dbContext.Course
                 select c).First();
    if(!result.Department.IsLoaded)
       {
          result.Department.Load(); //this will load the course.Department navigation property
          
       }
    
    //Assuming you have 1 - 1 relationship with course to department
    string departmentName = result.Department.Name;
