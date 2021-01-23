    public static class ControllerExtensions
    {
        public static Guid GetCurrentClientID(this ControllerBase controller)
        {
            return (Guid)controller.ControllerContext.HttpContext.Session["ClientID"];
        }
    }
