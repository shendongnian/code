    using (MyEntities context = new MyEntities())
    {
        var student =  new Student()
        {
          Name = "some value",
          Birthday = "some Birthday"
        };
        context.Student.AddObject(student);
        context.SaveChanges();
        int ID = table1.ID; // You will get here the Auto-Incremented table ID vaue.
    }
