    public class IsAnAdminAttribute : ValidationAttribute {
        protected override bool IsValid(object obj) {
            if (Membership.UserInRole("admin"))
                return true; // they can access it
            else
                return false; // can't access it
        }
    }
