    private static CmsCoreContext _coreContext;
    
    protected static CmsCoreContext CoreContext
    {
       get
       {
          if (!System.Web.Hosting.HostingEnvironment.IsHosted)
          {
             return _coreContext ?? (_coreContext = new CmsCoreContext());
          }
          
          var context = HttpContext.Current;
          if (context == null) throw new InvalidOperationException();
          
          if (!context.Items.Contains("CoreContext"))
          {
             context.Items.Add("CoreContext", new CmsCoreContext());
          }
          
          return (CmsCoreContext)context.Items["CoreContext"];
       }
    }
