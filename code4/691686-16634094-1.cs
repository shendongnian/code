    enum CommandType
    {
        Reboot,
        StartService,
        ShowMsg
    }
    [DataContract]
    class Command
    {
        [DataMember]
        public CommandType CmdType
        {
            get;
            set;
        }
        [DataMember]
        public string Value
        {
            get;
            set;
        }
        public CommandType(CommandType cmd, string value = null)
        {
            CmdType = cmd;
            Value = value;
        }
    }
