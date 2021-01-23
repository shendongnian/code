    void ReceiveTimerTick(object sender, EventArgs e)
    {
        var messages = _zeroMqSubscriber.GetMessages();
        foreach (var message in messages)
            _textbox.AppendText(message + Environment.NewLine);
    }
