    public class User
    {
        public void Validate(IUserRepository repo)
        {
            //Basic validation code
            if (string.IsNullOrEmpty(Username))
                throw new ValidationException("Username can not be a null or whitespace characters");
            if (string.IsNullOrEmpty(Password))
                throw new ValidationException("Password can not be a null or whitespace characters");
    
            //Complex validation code
            var user = repo.GetUserByUsername(Username);
            if (user != null && user.id != id)
                throw new ValidationException("Username must be unique")
        }
    }
