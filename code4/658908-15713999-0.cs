    class Command
    {
        public const string Name = "Null";
    
        public virtual string CommandName
        {
            get
            {
                return Name;
            }
        }
    }
    
    class StaticReference : Command
    {
        public new const string Name = "StaticRef";
    
        public virtual string CommandName
        {
            get
            {
                return Name;
            }
        }
    }
