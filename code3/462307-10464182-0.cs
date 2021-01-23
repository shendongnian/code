    class Student { }
    class PrimaryStudent : Student { }
    class SecondaryStudent : Student { }
    
            static void Main(string[] args)
            {
                var students = new List<Student> { new PrimaryStudent(), new PrimaryStudent(), new SecondaryStudent(), new Student() };
                Save(students);
            }
    
            private static void Save(List<Student> students)
            {
                HashSet<Type> studentTypes = new HashSet<Type>(students.Select(s => s.GetType()));
                foreach (var type in studentTypes)
                {
                    var studentsOfType = students.Where(s => s.GetType() == type).ToArray();
                    Console.WriteLine("Saving {0} students of type {1}", studentsOfType.Length, type.Name);
                }
    
            }
    Saving 2 students of type PrimaryStudent
    Saving 1 students of type SecondaryStudent
    Saving 1 students of type Student
