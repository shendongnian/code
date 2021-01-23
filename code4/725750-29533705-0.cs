    public static class ApiControllerExtensions
    {
        public static string GetBaseUrl(this ApiController controller)
        {
            return string.Concat(controller.Request.RequestUri.Scheme, "://", controller.Request.RequestUri.Authority);
        }
    }
