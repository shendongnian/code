    ... 
        var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
        if (commandService == null) return;
        var menuCommandId = new CommandID(CommandSet, CommandId);
        var menuItem = new OleMenuCommand(this.MenuItemCallback, menuCommandId);
        menuItem.BeforeQueryStatus +=
            new EventHandler(OnBeforeQueryStatus);
        commandService.AddCommand(menuItem);
    ...
