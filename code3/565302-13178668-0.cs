    var master = Sitecore.Configuration.Factory.GetDatabase("master");
    var target = Sitecore.Configuration.Factory.GetDatabase("web");
    Sitecore.Data.Database[] targetDatabases = { target };
    var languages = master.Languages;
    Sitecore.Publishing.PublishManager.PublishIncremental(master, targetDatabases, languages);
