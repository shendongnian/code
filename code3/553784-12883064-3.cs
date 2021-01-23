    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        return "User".Equals(custom, StringComparison.OrdinalIgnoreCase)
            ? User.Identity.Name
            : base.GetVaryByCustomString(context, custom);
    }
