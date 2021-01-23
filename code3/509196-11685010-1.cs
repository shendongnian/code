    public class MyModule: NancyModule
    {
        public MyModule()
        {
            After += ctx => {
               if (ctx.Request.Path == "/"){
                   //ctx.Response.Body is a stream containing the body.
               }
            };
        }
    }
