    static Logger logger = GetLogger();
    private static Logger GetLogger()
    {
        var logger = LogManager.GetCurrentClassLogger();
        var d1 = (DatabaseTarget)logger.Factory.Configuration
            .AllTargets.Where(t => t.Name == "d1").FirstOrDefault();
        d1.DBPassword = Encryption.ToInsecureString(
            Encryption.DecryptString(((NLog.Layouts.SimpleLayout)(d1.DBPassword)).Text));
        return logger;
    }
