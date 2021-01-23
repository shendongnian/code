    class Teacher
    {
        // class-level list of students
        private List<Student> _students = new List<Student>();
    
        public Teacher()
        {
            var random = new Random();
            var studentCount = random.Next(20,30);
    
            for(int i = 0; i < studentCount; i++)
            {
                _students.Add(new Student());
            }
        }
        // use _students from here on out
        public void AddPages(...) { ... }
    }
