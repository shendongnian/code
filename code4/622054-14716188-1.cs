    class CourseRepository
    {
        // DbContext and maybe other fields
    
        public void Add(Course c)
        {
    
            // Serialize the event field
            _courses.Add(c);   // calling entity framework functions
        }
    }
