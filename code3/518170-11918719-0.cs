    public class PlayerListEvent
    {
        private string m_sMessage;
        public PlayerListEvent(String sMessage)
        {
            m_sMessage = sMessage;
        }
        public Boolean MessageIsValid()
        {
            // Validate the incoming message
            return true;
        }
        public void ParseMessage() {
            // Perform the message parsing
        }
    }
