    public class UsersController : ApiController
    {
      [HttpGet]
      public User GetUser(int id);
      [HttpPost]
      public User AddUser(User model);
      [HttpPut]
      public User UpdateUser(User model);
      [HttpDelete]
      public User DeleteUser(int id);
    }
