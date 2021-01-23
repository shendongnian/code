    public class UsersController : ApiController
    {
        // GET http://service.url/api/Users
        public User GetAllUsers(){ ... }
        // GET http://service.url/api/Users/1
        public User GetUser(int id){ ... }
    
        // POST http://service.url/api/Users/
        // User model is passed in body of HTTP Request
        public User PostUser([FromBody]User model){ ... }
    
        // PUT http://service.url/api/Users/1
        // User model is passed in body of HTTP Request
        public User PutUser(int id, [FromBody]User model){ ... }
    
        // DELETE http://service.url/api/Users/1
        public User DeleteUser(int id){ ... }
    }
