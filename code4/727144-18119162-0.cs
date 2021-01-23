     private void skype_MessageStatus(ChatMessage msg, TChatMessageStatus status)
     {
           if (msg.Body.Contains("faty"))
           {
                skype.SendMessage(msg.Sender.Handle,"Go away fatty!");
           }
      }
    skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
