    public class StudentViewModel : PropertyChangedBase
    {
        public StudentModel Student { get; set; }
    
        public String StudentName
        {
            get { return Student.FirstName; }
            set
            {
                Student.FirstName = value;
                NotifyOfPropertyChange(() => Student.FirstName);
            }
        }
    
        public Double StudentGrade
        {
            get { return Student.GradePoint; }
            set
            {
                Student.GradePoint = value;
                NotifyOfPropertyChange(() => Student.GradePoint);
                NotifyOfPropertyChange(() => CanSaveStudent);
            }
        }
    
        public void SaveStudent()
        {
            MessageBox.Show(String.Format("Saved: {0} - ({1})", Student.FirstName, Student.GradePoint));
        }
    
        public StudentViewModel()
        {
            Student = new StudentModel { FirstName = "Tom Johnson", GradePoint = 3.7 };
        }
    
        public Boolean CanSaveStudent
        {
            get { return Student.GradePoint >= 0.0 && Student.GradePoint <= 4.0; }
        }
    }
