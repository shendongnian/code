    public class Class1
    {
        ChatUser user1 = new ChatUser();
        public Class1()
        {
            //List of Message for current User
            List<ChatMessage> lstChatMessages = user1.Messages.ToList();
            //Take firstMessage in sequence
            ChatMessage firstMessage = lstChatMessages.FirstOrDefault();
            //User from
            ChatUser UserFrom = firstMessage.UserFrom;
            //User To
            ChatUser UserTo = firstMessage.UserTo;
        }
    }
