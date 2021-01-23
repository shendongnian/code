    void HandleCommand(string command)
    {
        switch (command)
        {
            case (help):
               Console.WriteLine("List of useable verbs and nouns");
               break;
            default:
               Console.WriteLine("Invalid command");
               break;
        }
    }
