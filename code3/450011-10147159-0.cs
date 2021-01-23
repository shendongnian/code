    public class UsersViewModel
         {
         public UsersViewModel {
             AvailableUsers = new List<SelectListItem>();
         }
         MembershipUserCollection membershipuserscollection { get; set; }
         public List<MembershipUser> membershipuserslist { get; set; }
         public List<SelectListItem> AvailableUsers { get; private set; }
    }
