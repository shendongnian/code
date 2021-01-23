    public class CustomParameter : Parameter
    {
        protected override object Eval(HttpContext context, Control control)
        {
            MembershipUser cur_User = Membership.GetUser();
            return cur_User.ProviderUserKey;
        }
    }
