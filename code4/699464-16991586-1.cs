    [DisplayName("UserProfilePlugin")]
    public class UserProfilePlugin : IFunctionPlugin
    {
        public Dictionary<string, Type> GetFunctions()
        {
            return new Dictionary<string, Type> 
            {
                { "getCustomColor", typeof(GetCustomColorFunction) }
            };
        }
    }
    public class GetCustomColorFunction : Function
    {
        protected override Node Evaluate(Env env)
        {
            Guard.ExpectNumArguments(1, Arguments.Count(), this, Location);
            Guard.ExpectNode<Keyword>(Arguments[0], this, Arguments[0].Location);
            //the idea is that you would have many colors in a theme, this would be the name for a given color like 'bgColor', or 'foreColor'
            var colorAttrName = Arguments[0] as Keyword;
            
            //Lookup username
            // string username = HttpContext.Current.User.Identity.Name;
            //perform some kind of DB lookup using the username, get user theme info
            // UserProfile up = new UserProfile();
            // System.Drawing.Color c = up.GetColorByAttribute(colorAttrName.Value);
            //return the appropriate color using RGB/etc...
            // return new Color(c.R, c.G, c.B);
            return new Color(129, 129, 129);
        }
    }
