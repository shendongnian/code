    using (ServerManager serverManager = new ServerManager())
    {
        Configuration webConfig = serverManager.GetWebConfiguration("Default Web Site");
        ConfigurationSection section = webConfig.GetSection("system.webServer/defaultDocument");
        foreach (ConfigurationElement item in section.GetCollection("files"))
        {
            Console.WriteLine(item["value"]);
        }
    }
