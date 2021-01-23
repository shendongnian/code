    public class MyModule: NancyModule
    {
        public MyModule()
        {
            Get["/"] = x => {
                var x = _repo.X();
                var response = View["my_view", x];
                using (var ms = new MemoryStream())
                {
                    response.Contents(ms);
                    ms.Flush();
                    ms.Position = 0;
                    //now ms is a stream with the contents of the response.
                }
                return view;
            };
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
