    public class TextareaJsonResult : JsonResult
    {
        public TextareaJsonResult(object data)
        {
            this.Data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            bool shouldWrap = !context.HttpContext.Request.IsAjaxRequest();
            if (shouldWrap)
            {
                response.Write("<textarea>");
            }
            base.ExecuteResult(context);
            if (shouldWrap)
            {
                response.ContentType = "text/html";
                response.Write("</textarea>");
            }
        }
    }
