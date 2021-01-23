    public class AuthorizedToEdit 
    {
         protected override bool AuthorizeCore(string user, int itemId)
         {
             var userName = httpContext.User.Identity.Name;
             var authUsers = SubmissionRepository.GetAuthoriedUsers(itemId);
        
             return authUsers.Contains(user);
         }
    }
