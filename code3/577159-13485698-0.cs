    public class CustomActionResult:ViewResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);
            var t =  Task.Factory.StartNew(() =>
                 {
                      
                      while (true)
                       {
                          Thread.Sleep(1000);
                          context.HttpContext.Response.Write("<h1>hello</h1>");
                          context.HttpContext.Response.Flush();
                       }
                });
            Task.WaitAll(t);
        }
    }
