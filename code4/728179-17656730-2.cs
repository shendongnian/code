    public static class Helpers
    {
        // various methods such as the following...
        public static void GetDropdowns(this Controller controller)
        {
            var username = controller.HttpContext.User.Identity.Name;
            controller.ViewBag.Username = username;
        }
    }
