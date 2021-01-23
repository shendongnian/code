    public static void Updater()
    {
        try
        {
            var news = someServiceReference.Updater(DateTime clientSideLastUpdate);
            RenewDataInForms(news);
            Updater();
        }
        catch(ServerDiesOrWhatElseExcepption)
        {
            Updater()
        }
    }
