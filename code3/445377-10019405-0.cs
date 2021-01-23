    Dictionary<string, string> commandsAndResponses = new Dictionary<string, string>();
    commandsAndResponses.Add("hi", "what");
    // Add the rest
    
    if (commandsAndResponses.ContainsKey(command))
    {
        MessageBox.Show(command);
        skype.SendMessage(msg.Sender.Handle, nick + " Says: " +  commandsAndResponses[command]);
    }
