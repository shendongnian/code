    using (MyEntities context = new MyEntities())
    {
        var student =  new Student()
        {
          Name = "some value",
          Birthday = "some Birthday"
        };
        context.Students.AddObject(student);
        context.SaveChanges();
        int ID = student.ID; // You will get here the Auto-Incremented table ID value.
    }
