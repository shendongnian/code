    public interface IUserService
    {
        User GetUser(int userId, bool includeProfilePic);
    }
    public static class UserServiceExtensions
    {
        public static User GetUser(this IUserService userService, int userId)
        {
            return userService.GetUser(userId, false);
        }
    }
