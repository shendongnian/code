    msg = queue.Receive(TimeSpan.FromMilliseconds(500));
    if (msg != null)
    {
        msg.Formatter = new BinaryMessageFormatter();
        myImage = (MyImage)msg.Body;
    }
