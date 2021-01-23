    //To get all students
    private IEnumerable<Stundets> GetStudents()
    {
    using (StudentManager manager = new StudentManager())
    {
        return = manager.GetStudents();
    }
    }
    
    //To save Students
    //To get all students
    private IEnumerable<Stundets> SaveStudents()
    {
    using (StudentManager manager = new StudentManager())
    {
        return = manager.Save();
    }
    }
