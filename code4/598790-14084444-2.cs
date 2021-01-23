    public class UsersController : ApiController
    {
      // GET http://service.url/api/Users/1
      [HttpGet]
      public User GetUser(int id);
      // POST http://service.url/api/Users/?name=richard...
      [HttpPost]
      public User AddUser(User model);      
      // PUT http://service.url/api/Users/?id=1&name=Richard...
      [HttpPut]
      public User UpdateUser(User model);
      // DELETE http://service.url/api/Users/1
      [HttpDelete]
      public User DeleteUser(int id);
    }
