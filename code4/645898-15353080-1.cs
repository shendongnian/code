    private void AddBindings()
    {
        //Modified to inject session variable
        ninjectKernel.Bind<EFDbContext>().ToMethod(c => new EFDbContext((int)HttpContext.Current.Session["thisTenantID"]));
        ninjectKernel.Bind<IAppUserRepository>().To<EFAppUserRepository>();
        ninjectKernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>().WithConstructorArgument("tenantID", c => (int)HttpContext.Current.Session["thisTenantID"]);
    }
