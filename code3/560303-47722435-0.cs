    public interface IUserManager
    {
        Task<bool> IsUserInRole(string roleName);
    }
    public class UserManager1
    {
        public async Task<bool> IsUserInRole(string roleName)
        {
            return await _userManager.IsInRoleAsync(_profile.Id, roleName);
        }
    }
    public class UserManager2
    {
        public Task<bool> IsUserInRole(string roleName)
        {
            return Task.FromResult(Roles.IsUserInRole(roleName));
        }
    }
