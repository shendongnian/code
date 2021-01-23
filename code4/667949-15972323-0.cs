    public static class Interpreter
    {
        public static Command CreateCommand(string commandLine)
        {
            Command newCommand = new Command();
            newCommand.Name = commandLine.Split(' ')[0];
            newCommand.Parameters.Add(...)
            return newCommand
        } 
    }
