    private class FireOnCommandContext
    {
        public string Command { get; private set; }
        public BotShell Bot { get; private set; }
        public CommandArgs Args { get; private set; }
        public FireOnCommandContext(string command, BotShell bot, CommandArgs args)
        {
            Command = command;
            Bot = bot;
            Args = args;
        }
    }
    private void FireOnCommandProc(object context)
    {
        FireOnCommandContext fireOnCommandContext = (FireOnCommandContext)context;
        PluginBase plugin = Plugins.GetPlugin(Commands.GetInternalName(fireOnCommandContext.Command));
        plugin.FireOnCommand(fireOnCommandContext.Bot, fireOnCommandContext.Args);
    }
    ...
    FireOnCommandContext context = new FireOnCommandContext(this, newArgs);
    ThreadPool.QueueUserWorkItem(FireOnCommandProc, context);
