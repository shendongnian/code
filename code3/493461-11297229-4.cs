    public static class ControllerExtensions
    {
        public static Guid GetCurrentClientID(this HttpContextBase context)
        {
            return (Guid)context.Session["ClientID"];
        }
    }
