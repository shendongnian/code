    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        if (custom.Equals("user", StringComparison.OrdinalIgnoreCase))
        {
            return context.User.Identity.IsAuthenticated ? context.User.Identity.Name : string.Empty;
        }
        return base.GetVaryByCustomString(context, custom);
    }
