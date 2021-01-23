    class Course
    {
        internal string c_name {get; set;}
        public Student Student { get; private set; }
    
        public Course()
        {
            this.Student = new Student();
        }
    }
