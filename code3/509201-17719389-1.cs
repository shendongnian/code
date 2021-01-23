    public class TheModule : NancyModule
    {
        private readonly IViewRenderer _renderer;
        public TheModule(IViewRenderer renderer)
        {
               _renderer = renderer;
        
               Post["/sendmail"] = _ => {
                  
                    string emailBody;
                    var model = this.Bind<MyEmailModel>();
                    var res = _renderer.RenderView(this.Context, "email-template-view", model);
                    using ( var ms = new MemoryStream() ) {
                      res.Contents(ms);
                      ms.Flush();
                      ms.Position = 0;
                      emailBody = Encoding.UTF8.GetString( ms.ToArray() );
                    }
                    //send the email...
               };
        }
    }
