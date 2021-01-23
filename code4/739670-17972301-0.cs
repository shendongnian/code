        public void ToAdmin(Message message, SessionID sessionID)
        {
            // Check message type
            if (message.Header.GetField(Tags.MsgType) == MsgType.LOGON)
            {
                // Yes it is logon message
                // Check if local variables YourUserName and YourPassword are set
                if (!string.IsNullOrEmpty(YourUserName) && !string.IsNullOrEmpty(YourPassword))
                {
                    // Add Username and Password fields to logon message
                    ((Logon) message).Set(new Username(YourUserName));
                    ((Logon) message).Set(new Password(YourPassword));
                }
            }
        }
