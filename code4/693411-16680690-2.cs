    private class FireOnCommandContext
    {
        private string command;
        private BotShell bot;
        private CommandArgs args;
        public FireOnCommandContext(string command, BotShell bot, CommandArgs args)
        {
            this.command = command;
            this.bot = bot;
            this.args = args;
        }
        public string Command { get { return command; } }
        public BotShell Bot { get { return bot; } }
        public CommandArgs Args { get { return args; } }
    }
    private void FireOnCommandProc(object context)
    {
        FireOnCommandContext fireOnCommandContext = (FireOnCommandContext)context;
        PluginBase plugin = Plugins.GetPlugin(Commands.GetInternalName(fireOnCommandContext.Command));
        plugin.FireOnCommand(fireOnCommandContext.Bot, fireOnCommandContext.Args);
    }
    ...
    FireOnCommandContext context = new FireOnCommandContext(command, this, newArgs);
    ThreadPool.QueueUserWorkItem(FireOnCommandProc, context);
