    public partial class StudentService : IStudentService
    {
        Entities db = new Entities();
        public virtual Student GetStudentById(int studentId)
        {
            return db.SingleOrDefault(s => s.StudentID == studentId);
        }
        public virtual IList<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }
    }
