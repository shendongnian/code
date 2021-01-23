    public class MyModule: NancyModule
    {
        public MyModule()
        {
            After += ctx => {
               if (ctx.Request.Path == "/"){
                   using (var ms = new MemoryStream())
                   {
                       ctx.Response.Contents(ms);
                       ms.Flush();
                       ms.Position = 0;
                       //now ms is a stream with the contents of the response.
                   }
               }
            };
        }
    }
