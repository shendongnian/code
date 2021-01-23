    interface IStudent
    {
        string Name { get; }
        string EducationLevel { get; }
    }
    interface ITeacher
    {
        string Name { get; }
        string Department { get; }
    }
    public class Person: IStudent, ITeacher
    {
        public string EducationLevel
        {
            get { return String.Empty; }
        }
        public string Name
        {
            get { return String.Empty; }
        }
        public string Department
        {
            get { return String.Empty; }
        }
        
    }
