    Teacher teacher = new Teacher();
    teacher.MaxBobs = 1;
    teacher.Students = new Collection<Student>(); 
    var hasTooManyBobs = false;
    try 
    {
        teacher.AddStudent(new Student() { Name = "Bob" });
        teacher.AddStudent(new Student() { Name = "Bob" });
    }
    catch(TooManyBobsException)
    {
        hasTooManyBobs = true;
    }
    Assert.IsFalse(hasTooManyBobs);
