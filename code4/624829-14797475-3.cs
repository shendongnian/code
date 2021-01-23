    private readonly ZeroMqSubscriber _zeroMqSubscriber = 
            new ZeroMqSubscriber("tcp://127.0.0.1:5000");
    void ReceiveTimerTick(object sender, EventArgs e)
    {
        var messages = _zeroMqSubscriber.GetMessages();
        foreach (var message in messages)
            _textbox.AppendText(message + Environment.NewLine);
    }
