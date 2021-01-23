    // Model:
    public abstract class Person
        {
            [Key]
            public int PersonID { get; set; }
    
            [Required(ErrorMessage = "Last name is required.")]
            [Display(Name = "Last Name")]
            [MaxLength(50)]
            public string LastName { get; set; }
    
            [Required(ErrorMessage = "First name is required.")]
            [Column("FirstName")]
            [Display(Name = "First Name")]
            [MaxLength(50)]
            public string FirstMidName { get; set; }
    
            public string FullName
            {
                get
                {
                    return LastName + ", " + FirstMidName;
                }
            }
        }
----------
    // Repository:
    public class StudentRepository : IStudentRepository, IDisposable
        {
            private SchoolContext context;
    
            public StudentRepository(SchoolContext context)
            {
                this.context = context;
            }
    
            public IEnumerable<Student> GetStudents()
            {
                return context.Students.ToList();
            }
    
            public Student GetStudentByID(int id)
            {
                return context.Students.Find(id);
            }
    
            public void InsertStudent(Student student)
            {
                context.Students.Add(student);
            }
    
            public void DeleteStudent(int studentID)
            {
                Student student = context.Students.Find(studentID);
                context.Students.Remove(student);
            }
    
            public void UpdateStudent(Student student)
            {
                context.Entry(student).State = EntityState.Modified;
            }
    
            public void Save()
            {
                context.SaveChanges();
            }
    
            private bool disposed = false;
    
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                this.disposed = true;
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
