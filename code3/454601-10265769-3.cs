    List<Student> students = new List<Student>();
    public List<Student> ReturnStudentsIn(string groupName, string secondGroupName)
    {
        var stu = from s in students
                      where
                          (from g in s.StudentGroup where g.GroupName == groupName select g).Any()
                          && (from g in s.StudentGroup where g.GroupName == secondGroupName select g).Any() 
                      select s;
        return stu;
    }
