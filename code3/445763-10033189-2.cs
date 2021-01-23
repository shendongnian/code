    public Student[] ListStudents()
    {
       return GetStudentCollection().ToArray();
    }
    
    public IList<Student> GetStudentCollection()
    {
       var students = new List<Student>()
       {
    	   new Student { StudentID="bla", FirstName="bla", LastName="bla"},
    	   new Student { StudentID="bla1", FirstName="bla1", LastName="bla1"},
    	   new Student { StudentID="bla2", FirstName="bla2", LastName="bla2"}
       };
       return students();
    }
