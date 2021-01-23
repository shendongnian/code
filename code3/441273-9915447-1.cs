    void Main()
    {
        var students = new List<Student>()
        {
          new Student() { StudentID = 12345, Name = "Smith" },
          new Student() { StudentID = 12346, Name = "Jones" }
          };
    
        var terms = new List<Term>()
        {
            new Term() { StudentID=12345, TermID = 1234 },
            new Term() { StudentID=12345, TermID = 1235 },
            new Term() { StudentID=12345, TermID = 1236 },
            new Term() { StudentID=12345, TermID = 1237 },
            new Term() { StudentID=12346, TermID = 1233 },
            new Term() { StudentID=12346, TermID = 1234 },
        };
    
        var result = terms.GroupBy (tm => tm.StudentID)
                          .Select (gr => new
        {
            Name = students.First (s => s.StudentID == gr.Key).Name,
            Terms = gr.Select (g => g.TermID)
        });
    
    
        result.Dump();
    
    }
    
    // Define other methods and classes here
        public class Student
        {
            public int StudentID { get; set; }
            public string Name { get; set; }
        }
    
        public class Term
        {
            public int StudentID { get; set; }
            public int TermID { get; set; }
        }
