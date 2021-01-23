    List<OpenPop.Mime.Message> allaEmail = FetchAllMessages(...);
    StringBuilder builder = new StringBuilder();
    foreach(OpenPop.Mime.Message message in allaEmail)
    {
         OpenPop.Mime.MessagePart plainText = message.FindFirstPlainTextVersion();
         if(plainText != null)
         {
             // We found some plaintext!
             builder.Append(plainText.GetBodyAsText());
         } else
         {
             // Might include a part holding html instead
             OpenPop.Mime.MessagePart html = message.FindFirstHtmlVersion();
             if(html != null)
             {
                 // We found some html!
                 builder.Append(html.GetBodyAsText());
             }
         }
    }
    MessageBox.Show(builder.ToString());
}
