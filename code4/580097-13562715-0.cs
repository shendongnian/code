    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<StudentViewModel> StudentViewModels { get; private set; }
        public MainWindowViewModel()
        {
            StudentViewModels = new ObservableCollection<StudentViewModel>();
        }
    }
    class StudentViewModel : ViewModelBase
    {
        public Student Student { get; private set; }
        
        public StudentViewModel()
        {
            Student = new Student();
        }
        public StudentViewModel(Student model)
        {
            Student = model;
        }
        public void ChangeStudent()
        {
            Student.changeStudent();
        }
    }
    public class Student : ViewModelBase
    {
        public String studentFirstName;
        public String StudentFirstName
        {
            get { return studentFirstName; }
            set
            {
                if (studentFirstName != value)
                {
                    studentFirstName = value;
                    OnPropertyChanged("StudentFirstName");
                }
            }
        }
        public String studentLastName;
        public String StudentLastName
        {
            get { return this.studentLastName; }
            set
            {
                if (studentLastName != value)
                {
                    studentLastName = value;
                    OnPropertyChanged("StudentLastName");
                }
            }
        }
        public Student() { }
        public void changeStudent()
        {
            StudentLastName = "McRonald";
        }
    }
