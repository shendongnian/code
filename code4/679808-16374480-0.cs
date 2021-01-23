    var repository = LogManager.GetRepository();
    if (repository != null)
    {
        if (debug)
        {
            repository.Threshold = Level.Debug;
        }
        else
        {
            repository.Threshold = Level.Info;
        }
    }
