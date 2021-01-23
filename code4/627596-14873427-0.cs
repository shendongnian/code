    interface IPerson
    {
        string Name { get; }
    }
    
    interface IStudent : IPerson
    {
        string EducationLevel { get; }
    }
    
    interface ITeacher : IPerson
    {
        string Department { get; }
    }
