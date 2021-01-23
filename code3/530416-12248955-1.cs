    [AttributeUsage(AttributeTargets.Class)]
    public class AuthenticationRequired : Attribute
    {
        public AuthenticationRequired(bool isMemberRequired)
        {
            Value = isMemberRequired;
        }
    
        public bool Value { get; private set; }
    }
    public class Utility
    {
        public static T GetCustomAttribute<T>(Type classType) where T : Attribute
        {
            object Result = null;
    
            System.Reflection.MemberInfo Info = classType;
    
            foreach (var Attr in Info.GetCustomAttributes(true))
            {
                if (Attr.GetType() == typeof(T))
                {
                    Result = Attr;
                    break;
                }
            }
            return (T)Result;
        }
    }
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            AuthenticationRequired AttrAuth = Utility.GetCustomAttribute<AuthenticationRequired>(this.GetType());
            if (AttrAuth != null && AttrAuth.Value)
            {
                if(!IsMember)
                    HttpContext.Current.Response.Redirect("Membership.aspx");
            }
        }
    }
