    abstract class Person : IPerson
    {
        public virtual string Name { get; set; }
    }
    class Student : Person, IStudent
    {
        public string EducationLevel { get; set; }
    }
    class Teacher : Person, ITeacher
    {
        public string Department { get; set; }
    }
    class StudentTeacher : Person, IStudent, ITeacher
    {
        public string EducationLevel { get; set; }
        public string Department { get; set; }
    }
