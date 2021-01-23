    class User {
        [Key, ForeginKey("Project")]
        int id
        public Virtual Project Project{get; set;}
    }
    class Project {
        int id
        public virtual User User {get; set;}
    }
