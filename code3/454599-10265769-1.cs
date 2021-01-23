    List<Student> students = new List<Student>();
    public List<Student> ReturnStudentsIn(string groupName, string secondGroupName)
    {
        List<Student> student = (from g in students
                                 where ((from t in g.StudentGroup where t.GroupName == groupName select t).Any()) 
                                 && ((from b in g.StudentGroup where b.GroupName == secondGroupName select b).Any())
                                 select g).ToList();
        return student;
    }
