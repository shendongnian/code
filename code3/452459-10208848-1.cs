    string SendAndWait(string command)
    {
        StateObject state = new StateObject(command);
        state.ReplyReceived = new ManualResetEvent(false);
        try
        {
            SerialPortHandler.Instance.SendRequest(command, state);
            state.ReplyReceived.WaitOne();
        }
        finally
        {
            state.ReplyReceived.Close();
        }
        return state.Reply;
    }
