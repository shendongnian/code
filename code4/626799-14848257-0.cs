    List<string> messages = new List<string>();
    foreach (Char c in skype.MissedChats)
    {
        try
        {
            messages.Add(c.Name);
        }
        catch (COMException) { } // Invalid chat
    }
