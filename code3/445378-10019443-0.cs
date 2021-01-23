    string[] lines = richTextBox1.Text.Split('\n'); // split on line
    foreach(string ln in lines)
    {
        string[] commands = ln.Split(':');
        if(commands.Length == 2) 
        {
            // first statement 
            skype.SendMessage(msg.Sender.Handle, string.Format("{0} Says: {1}",nick, command[0]); 
            // second statement
            skype.SendMessage(msg.Sender.Handle, string.Format("{0} Says: {1}",nick, command[1]);
        }
    }
