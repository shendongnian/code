    public override string GetVaryByCustomString(HttpContext context, 
    string arg)
    {
       if(arg == "productIdInUrl")
       {
          return context.Request.RawUrl;
       }
       return base.GetVaryByCustomString(context, arg);
    }
