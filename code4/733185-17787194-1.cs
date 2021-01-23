    private StudentManager manager;
    //To get all students
    private IEnumerable<Stundets> GetStudents()
    {
    using (manager = new StudentManager())
    {
        return = manager.GetStudents();
    }
    }
    
    //To save Students
    //To get all students
    private IEnumerable<Stundets> SaveStudents()
    {
    using (manager = new StudentManager())
    {
        return = manager.Save();
    }
    }
