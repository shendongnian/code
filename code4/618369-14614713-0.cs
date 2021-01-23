    //Maps to /Users endpoint
    [HttpGet, GET("/Users")]
    public IEnumerable<User> GetAllUsers()
    {
       //Code
    }
    
    //Maps to /Users/{id} endpoint
    [HttpGet, GET("/Users/{id)"]
    public User GetUser(int id)
    {
       //Code
    }
    
    //Maps to /Users/{id}/Enrollments endpoint
    [HttpGet, GET("/Users/{id}/Enrollments")]
    public IEnumerable<Enrollment> GetUserEnrollments(int id)
    {
       //Code
    }
    
    //Maps to /Users/{userid}/Enrollments/{id}
    [HttpGet, GET("/Users/{userid}/Enrollments/{id}")]
    public IEnumerable<Enrollment> GetUserEnrollment(int userid, int id)
    {
       //Code
    }
