    MyDataProvider dp = new MyDataProvider("abc", data);
    
    List<Student> students = new List<Student>();
    students.AddRange(dp.GetStudents());
    
    List<Teacher> teachers = new List<Teacher>();
    teachers.AddRange(dp.GetTeachers());
