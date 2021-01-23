    this.courseList.Items.Add("All");       
    foreach (var items in ldc.Courses.OrderBy(x => x.CourseID))
     {
       this.courseList.Items.Add(items.CourseID.ToString() + " : " + items.CourseName);
     }
    this.courseList.Items.Add("Others"); 
