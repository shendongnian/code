    public class AccessControlModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest +=
                (s, e) =>
                {
                    if (!AccessPermitted(context))
                        context.Response.Redirect(AccessDeniedUrl);
                    
                    // Otherwise, IIS will serve the file as normal
                };
        }
        //...
    }
---
    <httpModules>
       <add name="AccessControlModule" type="MyNamespace.AccessControlModule" />
    </httpModules>
