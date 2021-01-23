    public interface IPerson {
        string Name { get; set; }
    }
    public void CreateTeacher(IPerson teacher) {
        teacher.Name = "Teacher name";
    }
    IPerson teacher = new Teacher();
    CreateTeacher(teacher);
