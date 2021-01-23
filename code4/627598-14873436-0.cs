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
    
    IPerson P1 = SomeStudent;
    IPerson P2 = SomeTeacher;
    IStudent S = P1 as IStudent;
    ITeacher T = P2 as ITeacher;
