        private static Object CloneObject(Object Source)
        {
            MemoryStream Stream = new MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Formatter.Serialize(Stream, Source);
            Stream.Position = 0;
            object Clone = (object)Formatter.Deserialize(Stream);
            Stream.Close(); Stream.Dispose();
            return Clone;
        }
        public static System.Web.HttpContext ThreadingFixHttpContext()
        {
            //If this method is called from a new thread there is issues holding httpContext.current (which is injected from parent thread in AniReturnedPaymentsFetch.ascx.cs
            //The parent http current will die of its own accord (because it is from a different thread)
            //So we clone it into thread current principal. 
            System.Security.Principal.WindowsIdentity ThreadIdentity =
                (System.Security.Principal.WindowsIdentity)CloneObject(System.Web.HttpContext.Current.User.Identity);
            
            //Then create a new httpcontext using the parent's request & response, so now the http current belongs to this thread and will not die.
            var request = System.Web.HttpContext.Current.Request;
            var response = System.Web.HttpContext.Current.Response;
            var ctx = new System.Web.HttpContext(request, response);
            ctx.User = new System.Security.Principal.WindowsPrincipal(ThreadIdentity);
            return ctx;
        }
