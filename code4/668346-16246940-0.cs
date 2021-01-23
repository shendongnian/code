        public int studentId { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
