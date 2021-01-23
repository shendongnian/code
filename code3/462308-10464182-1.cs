    class Program
    {
        class Student { }
        class PrimaryStudent : Student { }
        class SecondaryStudent : Student { }
    
        private void Run()
        {
            var students = new List<Student> { new PrimaryStudent(), new PrimaryStudent(), new SecondaryStudent(), new Student() };
            Save(@"C:\University", students);
        }
    
        private void Save(string basePath, List<Student> students)
        {
            HashSet<Type> studentTypes = new HashSet<Type>(students.Select(s => s.GetType()));
            foreach (var type in studentTypes)
            {
                var studentsOfType = students.Where(s => s.GetType() == type).ToArray();
                string path = Path.Combine(basePath, type.Name);
                Console.WriteLine("Saving {0} students of type {1} to {2}", studentsOfType.Length, type.Name, path);
            }
    
        }
    Saving 2 students of type PrimaryStudent to C:\University\PrimaryStudent
    Saving 1 students of type SecondaryStudent to C:\University\SecondaryStudent
    Saving 1 students of type Student to C:\University\Student
