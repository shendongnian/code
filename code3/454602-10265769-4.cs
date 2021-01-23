    List<Student> students = new List<Student>();
    public List<Student> ReturnStudentsIn(string groupName, string secondGroupName)
    {
        List<Student> stu = (from s in students
                      where
                          (from g in s.StudentGroup where g.GroupName == "A" select g).Any()
                       && (from g in s.StudentGroup where g.GroupName == "B" select g).Any() 
                      select s).ToList();
        return stu;
    }
