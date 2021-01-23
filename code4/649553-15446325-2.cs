    class View
    {
        public void Login(string username, string password)
        {
            try
            {
                var user = _users.SelectUser(username, password);
                MessageBox.Show(
                    string.Format("valid user: {0}", user.UserName));
            }
            catch (InvalidUserNameOrPasswordException)
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
    public class Users
    {
        public User SelectUser(string userName, string password)
        {
            if (!ValidUser)
            {
                throw InvalidUserNameOrPasswordException();
            }
            return new User();
        }
    }
