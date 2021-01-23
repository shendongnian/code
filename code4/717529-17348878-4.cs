    private void UpdateTextBox(object txt)
    {
        if (msg_log.Dispatcher.CheckAccess())
        {
            if (txt != null)
                msg_log.Text = txt.ToString();
        }
        else
        {
            msg_log.Dispatcher.Invoke(new UpdateText(UpdateTextBox), txt);
        }
    }
