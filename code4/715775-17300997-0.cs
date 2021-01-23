    public class CheckMessage
    {
        private List<MT101> message101 = new List<MT101>();
        public List<MT101> Messge101 { get { return message101; } }
        public List<MT101> CheckMt101Message(string[] messageBody)
        {
            MT101 buildMessage = new MT101();
            .
            .
            . perform all the neccessary logic to add into buildMessage and then return the
            . Message101 object
            Message101.Add(buildMessage);
            return Message101;
        }
    }
