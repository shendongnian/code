    ...
    //Before calling UpdateStudent, make sure your StudentId property is set
    student.StudentId = 123;
    ....
    public void UpdateStudent(Student student)
    {
        using (IDataContext ctx = DataContext.Instance())
        {
            var rep = ctx.GetRepository<Student>();
            rep.Update(student);
        }
    }
