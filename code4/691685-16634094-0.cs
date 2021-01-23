    enum CommandType
    {
        Reboot,
        StartService,
        ShowMsg
    }
    class Command
    {
        public CommandType type
        {
            get;
            set;
        }
        public string value
        {
            get;
            set;
        }
        public CommandType(CommandType cmd, string value = null)
        {
            type = cmd;
            this.value = value;
        }
    }
