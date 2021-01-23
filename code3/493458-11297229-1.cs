    public static class ControllerExtensions
    {
        public static Guid CurrentClientID(this HttpContextBase context)
        {
            return (Guid)context.Session["ClientID"];
        }
    }
