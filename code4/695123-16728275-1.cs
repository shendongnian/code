    [Handles(Command.Login)]
    public class LoginCommandManager : ICommandManager
    {
        public ReturnPacket DoYourStuff()
        {
            var ret = new ReturnPacket();
            /* Do some stuff */
            return ret;
        }
    }
