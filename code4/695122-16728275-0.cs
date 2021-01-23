    public class HandlesAttribute : Attribute
    {
        public Command HandlesCommand { get; private set; }
        public HandlesAttribute(Command cmd)
        {
            this.HandlesCommand = cmd;
        }
    }
