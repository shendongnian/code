     public static IEnumerable<Student> ReturnSomething()
            {
                IList<Student> studentList = new List<Student>()
                {
                    new Student()
                        {studentId = 1, studentName = "Bill", subject = "Science", studentClass = "nine", RollNumber = 01},
                    new Student()
                        {studentId = 2, studentName = "Steve", subject = "Arts", studentClass = "ten", RollNumber = 03},
                    new Student()
                        {studentId = 3, studentName = "Ram", subject = "Commerce", studentClass = "nine", RollNumber = 05},
                    new Student()
                        {studentId = 1, studentName = "Moin", subject = "Science", studentClass = "ten", RollNumber = 06}
                };
    
                return studentList;
            }
