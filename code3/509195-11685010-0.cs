    public class MyModule: NancyModule
    {
        public MyModule()
        {
            After += ctx => {
               if (ctx.Path == "/"){
                   //ctx.Response.Body is a stream containing the body.
               }
            };
        }
    }
