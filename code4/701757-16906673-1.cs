    public string main(IInputter inputter)
    {
        string receivedInput = null;
        inputter.ReceivedInput += (s, e) => receivedInput = e.Text;
        // Wait for input? Is probably a better way than a loop. Look into Rx or async
        while (receivedInput == null)
        {
            // Received input
        } 
    }
