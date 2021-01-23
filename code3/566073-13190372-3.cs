    public void AppendConversation(string str)
    {   
        conversation.Append(str) // Sorry, I was unable to detect the type of 'conversation'
        new TextRange(rtbConversation.Document.ContentStart,
                      rtbConversation.Document.ContentEnd).Text =
                        conversation.ToString();
        rtbConversation.Focus();
        int TextLength = new TextRange(rtbConversation.Document.ContentStart,
                                       rtbConversation.Document.ContentEnd).Text.Length;
        TextPointer tr = rtbConversation.Document.ContentStart.GetPositionAtOffset(
            TextLength - 1, LogicalDirection.Forward);
        rtbConversation.Selection.Select(tr, tr);
        rtbConversation.ScrollToEnd();
        rtbSendMessage.Focus();
    }
