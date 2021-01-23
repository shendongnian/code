    //Drop and re-create all Auth and registration tables
    var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
    if (appSettings.Get("RecreateAuthTables", false))
        authRepo.DropAndReCreateTables(); 
    else
        authRepo.CreateMissingTables(); //Create only the missing tables
