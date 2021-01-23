    public override string GetVaryByCustomString(HttpContext context, string arg)
    {
        if (arg == "host")
        {
            return context.Request.Headers["host"];
        }
        // whatever you have already, or just String.Empty
        return String.Empty;
    }
