    public string main(IInputter inputter)
    {
        string receivedInput = null;
        inputter.ReceivedInput += (s, e) => YourLibrary.DoSomething(e.Text);
    }
