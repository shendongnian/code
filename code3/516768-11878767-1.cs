    XDocument doc = XDocument.Parse("<Responses> <Response0>     <Action>sendMessage</Action>     <Data>         <AcceptReport>             <StatusCode>0</StatusCode>             <StatusText>Message accepted for delivery</StatusText>             <MessageID>89c8011c-e291-44c3-ac72-cd35c76cb29d</MessageID>             <Recipient>+85568922903</Recipient>         </AcceptReport>     </Data> </Response0> </Responses> ");
    
    var message = from item in doc.Descendants("AcceptReport")
                   select new { 
                        StatusText = item.Element("StatusText").Value,
                        MessageID = item.Element("MessageID").Value,
                        Recipient = item.Element("Recipient").Value 
                   };
    foreach (var el in message)
    {
        Console.WriteLine(el.MessageID + " " +el.Recipient + " " + el.StatusText);
    }
