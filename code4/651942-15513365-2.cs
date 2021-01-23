    var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>(); //If using and RDBMS to persist UserAuth, we must create required tables
    if (appSettings.Get("RecreateAuthTables", false))
        authRepo.DropAndReCreateTables(); //Drop and re-create all Auth and registration tables
    else
        authRepo.CreateMissingTables();   //Create only the missing tables
