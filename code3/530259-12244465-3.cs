        Message message = new Message
                                          {
                                              RecipientName = tbRecipientName.Text.Trim(),
                                              MessageContent = tbMessageContent.Text.Trim()
                                          };
        
                    if (!string.IsNullOrWhiteSpace(message.RecipientName) && !string.IsNullOrEmpty(message.MessageContent))
                    {
                        // Call the client adapter to send the message to the particular recipient instantly.
                        ClientAdapter.Instance.SendMessage(message);
    }
