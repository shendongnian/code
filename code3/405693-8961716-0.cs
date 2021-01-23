    public void MyMethod(TextReader reader)
    {
        for (int i = 0; i < robot.noOfCommands; i++)
        {
            robot.readCommand(reader.ReadLine());
        }
    }
