    namespace Company.BLL
    {
        public class Fido: IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                //hard-coding like this is not acceptable
                var assembly = Assembly.GetAssembly(context.CurrentHandler.GetType());
                var type = assembly.GetType("Company.Web.FidoHelper");
                object appInstance = Activator.CreateInstance(type);
                type.InvokeMember("DoSomething", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, appInstance, new object[] { context });
                context.Response.End();
            }
        }
    }
