    public Course AddCourse()
    {
         var course = new Course();
         course.CourseName = Console.ReadLine().ToString();
         // ... more readlines
         return course;
     }
