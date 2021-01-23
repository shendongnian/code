    void UpdateStatus(string textMessage)
    {
      if (richTextBox.InvokeRequired)
      {
        richTextBox.Invoke(new MethodInvoker(() => UpdateStatus(textMessage)));
        return;
      }
    
      richTextBox.AppendText(textMessage + Environment.NewLine);
    }
