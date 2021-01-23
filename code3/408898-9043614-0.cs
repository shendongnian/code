    enum ReadState { Waiting, Reading, Finished }
    static string ReadMessage(SerialPort port)
    {
        var messageBuffer = new StringBuilder("S");
        var state = ReadState.Waiting;
        while (state != ReadState.Finished)
        {
            switch (state)
            {
            case ReadState.Waiting:
                if (port.ReadChar() == 'S')
                {
                    state = ReadState.Reading;
                }
                break;
            case ReadState.Reading:
                messageBuffer.Append(port.ReadTo("E"));
                state = ReadState.Finished;
                break;
            }
        }
        return messageBuffer.ToString();
    }
