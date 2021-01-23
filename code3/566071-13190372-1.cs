    public void AppendConversation(string str)
    {   
        conversation.Append(str) // Sorry, I was unable to detect the type of 'conversation'
        #region rtbConversation.Text = conversation.ToString();
        // rtbConversation.Text = conversation.ToString();
        new TextRange(rtbConversation.Document.ContentStart, rtbConversation.Document.ContentEnd).Text = conversation.ToString();
        // rtbConversation.Text = conversation.ToString();
        #endregion
        #region rtbConversation.Focus();
        // rtbConversation.Focus();
        rtbConversation.Focus();
        // rtbConversation.Focus();
        #endregion
        #region rtbConversation.SelectionStart = rtbConversation.Text.Length - 1;
        // rtbConversation.SelectionStart = rtbConversation.Text.Length - 1;
        int TextLength = new TextRange(rtbConversation.Document.ContentStart, rtbConversation.Document.ContentEnd).Text.Length;
        TextPointer tr = rtbConversation.Document.ContentStart.GetPositionAtOffset(TextLength - 1, LogicalDirection.Forward);
        rtbConversation.Selection.Select(tr, tr);
        // rtbConversation.SelectionStart = rtbConversation.Text.Length - 1;
        #endregion
        #region rtbConversation.ScrollToCaret();
        // rtbConversation.ScrollToCaret();
        rtbConversation.ScrollToEnd();
        // rtbConversation.ScrollToCaret();
        #endregion
        #region rtbSendMessage.Focus();
        //rtbSendMessage.Focus();
        rtbSendMessage.Focus();
        //rtbSendMessage.Focus();
        #endregion
    }
