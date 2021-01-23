    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        var myClass = (MyClass)context.Items["model"];
        ...
    }
