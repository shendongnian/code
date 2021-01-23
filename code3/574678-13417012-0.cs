    public override string GetVaryByCustomString(HttpContext context, string arg) 
    { 
      if(arg.ToLower() == “username” && context.User.Identity.IsAuthenticated) return context.User.Identity.Name;
     
      return base.GetVaryByCustomString(context, arg); 
    }
