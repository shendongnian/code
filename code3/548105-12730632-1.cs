    class Chat
        {
            private User user;
    
            private Message message;
    
            public string UserName
            {
                get
                {
                    return user.Username;
                }
            }
    
            public string MessageText
            {
                get
                {
                    return message.MessageText;
                }
            }
        }
