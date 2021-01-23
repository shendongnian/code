    Lazy<bool> copyLocal = new Lazy<bool>(() =>
        container.GetInstance<IDatabaseManager>().RunQuery(CopyLocalQuery));
    container.RegisterInitializer<FileCopier>(copier =>
    {
        copier.CopyLocal = copyLocal.Value;
    });
