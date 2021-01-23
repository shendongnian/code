    public class MyActionResult : ActionResult
    {
        private readonly MyService _service;
        public MyActionResult(MyService service)
        {
            _service = service;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.BufferOutput = true;
            response.ContentType = "text/html";
            var wait = new ManualResetEvent(false);
            _service.GetModels((model, state) =>
            {
                var httpResponse = (HttpResponseBase)state;
                httpResponse.BufferOutput = true;
                httpResponse.ContentType = "text/html";
                var serializer = new JavaScriptSerializer();
                var script = string.Format(
                    "<script type=\"text/javascript\">window.parent.callback({0});</script>",
                    serializer.Serialize(model)
                );
                httpResponse.Write(script);
                httpResponse.Flush();
            },
            response,
            () =>
            {
                wait.Set();
            });
            wait.WaitOne();
        }
    }
