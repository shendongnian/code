    #if DEBUG
    CustomerConnectionString = ConfigurationManager.ConnectionStrings["kundenEntities"].ConnectionString;
    ProjectsConnectionString = ConfigurationManager.ConnectionStrings["projekteEntities"].ConnectionString;
    #else
    CustomerConnectionString = ConfigurationManager.ConnectionStrings["kundenEntitiesRelease"].ConnectionString;
    ProjectsConnectionString = ConfigurationManager.ConnectionStrings["projekteEntitiesRelease"].ConnectionString;
    #endif
