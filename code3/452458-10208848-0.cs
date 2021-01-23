    string SendAndWait(string command)
    {
        StateObject state = new StateObject(command);
        SerialPortHandler.Instance.SendRequest(command, state);
        while (String.IsNullOrWhitespace(state.Reply))
            Thread.Sleep(100);
        return state.Reply;
    }
