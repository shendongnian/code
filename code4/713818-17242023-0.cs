    public void DisplayMessage<T>(T message)
    {
        //do stuff with s
        if (message is string)
        {
            Console.WriteLine(message);
        }
    }
    Action<string> messageTarget = new Action<string>(DisplayMessage);
    messageTarget.Invoke("Testing");  //or use beginInvoke/endInvoke
