    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;
        public StudentController()
        {
            this.studentRepository = new StudentRepository(new SchoolContext());
        }
    }
