    public class LearningTeacher : ITeacher, IStudent
    {
        Teacher _teacher;
        Student _student;
    
        public LearningTeacher(string name, string educationalLevel,
                               string department)
        {
            _student = new Student(name, educationalLevel);
            _teacher = new Teacher(name, department);
        }
    
        public string EducationLevel
        {
            get { return _student.EducationLevel; }
        }
    
        public string Department
        {
            get { return _teacher.Department; }
        }
    
        public string Name
        {
            get { return _student.Name; }
        }
    }
