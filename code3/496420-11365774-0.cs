    class Program {
        static void Main(string[] args) {
            using ( StudentDBContext efc = new StudentDBContext()) {
                foreach (var v in efc.Students) {
                    Console.WriteLine("{0}", v.StudentName);
                    foreach (var vv in v.Notes) {
                        Console.WriteLine("    {0}", vv.Message);
                    }
                }
            }
        }
    }
    public class Student {
        public Student() {
            //Notes = new List<Note>();
        }
         [Key]
         public int StudentID {get; set;}
         public virtual string StudentName {get; set;}
         public virtual ICollection<Note> Notes {get; set;}
    }
    public class Note {
     [Key]
     public int NoteID {get; set;}
     public int StudentID {get; set;}
     public string Message {get; set;}
    }
    class StudentDBContext:DbContext {
        public DbSet<Student> Students { get; set; }
        public DbSet<Note> Notes { get; set; }        
    }
