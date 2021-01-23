    public void Application_Start(object s, EventArgs e)
    {
        Container container = new Container();
        Bootstrap(container);
        InitializeApplication(container);
    }
    private void InitializeApplication(
        Container container)
    {
        using (this.container.BeginLifetimeScope())
        {
            var pluginManager = this.container
                .GetInstance<PluginManagerService>();
            pluginManager.LinkPluginsWithDatabase();
            var unitOfWork =
                container.GetInstance<IUnitOfWork>();
            unitOfWork.Save();
        }
    }
