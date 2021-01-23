    var messages = MailMessageQueue.ToList<MailMessage>(); //Define your MailMessageQueue
    foreach (var message in messages)
    {
     
       foreach (var attachment in message.Attachements)
       {
          var path = Path.GetFullPath(attachment.Name);
          //You can use StreamReader in order to parse
         ...... 
       }
    }
