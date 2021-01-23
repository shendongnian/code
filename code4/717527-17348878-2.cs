    private void UpdateTextBox(object txt)
    {
        if (msg_log.Dispatcher.CheckAccess())
        {
            Dispatcher.Invoke(new UpdateText(UpdateTextBox), txt);
        }
        else
        {
            msg_log.Dispatcher.Invoke(new UpdateText(msg_log.UpdateTextBox), txt);
        }
    }
