    Bind<IDbConnectionFactory>()
        .To<SqlConnectionFactory>()
        .WithConstructorArgument("connectionString",
    ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
	
