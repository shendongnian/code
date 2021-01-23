        string title = "My tile goes here";
        string text = "Do you want to Update this record?";
        MessageBox messageBox = new MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.YesOrNo, MessageBox.MessageBoxStyle.StyleA);
        messageBox.SuccessEvent.Add("YesModClick");
        messageBox.FailedEvent.Add("NoClick");
        PopupBox.Text = messageBox.Show(this);
    
