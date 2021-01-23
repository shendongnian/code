    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var stream = filterContext.HttpContext.Request.InputStream;
        var data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        Log(Encoding.UTF8.GetString(data));
    }
