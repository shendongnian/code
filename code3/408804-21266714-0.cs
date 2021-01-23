    public class WsdlInterceptionHttpModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (sender, e) =>
            {
                var context = application.Context;
                if (IsRequestForWsdl(context.Request))
                {
                    context.Response.Filter = 
                        new WsdlAnnotationsFilterDecorator(context.Response.Filter);
                }
            };
        }
        private static bool IsRequestForWsdl(HttpRequest request) { ... }
    }
