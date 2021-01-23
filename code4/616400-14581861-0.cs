    // IDbConnection binding
    Bind<IDbConnection>().ToMethod(x => {
                              var constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                              var conn = new SqlConnection(constr);
                              conn.Open();
                              return conn;})
                         .InRequestScope();
    
    // ommited fill all properties of type
    Bind<ICurrent>().To<Current>(); // .InRequestScope() - just suggestion
    Bind<ILogger>().To<Logger>();
    Bind<IMembershipService>().To<SpaceMembership>();
    Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();
    // for this: Ninject.Extensions.Conventions has to be referenced
    Bind(x=> x.From("Space360.DB")
              .SelectAllClasses().InheritedFrom<IRepository>()
              .BindDefaultInterface()
           // .Configure(b => b.InRequestScope())
         );
