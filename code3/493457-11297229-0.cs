    public static class ControllerExtensions
    {
        public static Guid CurrentClientID(this ControllerBase controller)
        {
            return (Guid)controller.ControllerContext.HttpContext.Session["ClientID"];
        }
    }
