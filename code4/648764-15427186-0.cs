    public LibraryStudentMap()
    {
        EntityName("LibraryStudent");
        Table("LibraryStudents");
        Id(x => x.StudentId).GeneratedBy.Assigned();
    }
    public LabStudentMap()
    {
        EntityName("LabStudent");
        Table("LabStudents");
        Id(x => x.StudentId).GeneratedBy.Assigned();
    }
    public LibraryMap()
    {
        References(x => x.Student).EntityName("LibraryStudent");
    }
    public LabMap()
    {
        References(x => x.Student).EntityName("LabStudent");
    }
