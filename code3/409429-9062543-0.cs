    public class Handler1: IHttpHandler
    {
        static Handler1()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (string.Equals(e.Name, "ClassLibrary1", StringComparison.OrdinalIgnoreCase))
                {
                    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Handler.ClassLibrary1.dll"))
                    {
                        var buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        return Assembly.Load(buffer);
                    }
                }
                return null;
            };
        }
        public void ProcessRequest(HttpContext context)
        {
            var mtd = Type.GetType("ClassLibrary1.Class1, ClassLibrary1").GetMethod("Hello", BindingFlags.Static | BindingFlags.Public);
            var result = (string)mtd.Invoke(null, null);
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
