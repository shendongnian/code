    using (ServerManager serverManager = new ServerManager())
    {
        Configuration webConfig = serverManager.GetWebConfiguration("Default Web Site");
        DefaultDocumentSection section = (DefaultDocumentSection)webConfig.GetSection("system.webServer/defaultDocument", typeof(DefaultDocumentSection));
        foreach (FileElement item in section.Files)
        {
            Console.WriteLine(item.Value);
        }
    }
