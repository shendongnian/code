    List<Student> students = new List<Student>();
    public List<Student> ReturnStudentByGroupName(string groupName, secondGroupName)
    {
        List<Student> student = (from g in students
                                 where ((from t in g.StudentGroup where t.GroupName == groupName select t).Any()) 
                                 && ((from t in g.StudentGroup where t.GroupName == secondGroupName select t).Any())
                                 select g).ToList();
        return student;
    }
