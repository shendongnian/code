    public Mailbox[] ListMailboxes(string reference, string pattern) 
    {
        IdlePause();
        var x = new List<Mailbox>();
        string command = GetTag() + "LIST " + reference.QuoteString() + " " + pattern.QuoteString();
        string reg = "\\* LIST \\(([^\\)]*)\\) \\\"([^\\\"]+)\\\" \\\"?([^\\\"]+)\\\"?";
        string response = SendCommandGetResponse(command);
        Match m = Regex.Match(response, reg);
        while (m.Groups.Count > 1) 
        {
            Mailbox mailbox = new Mailbox(m.Groups[3].ToString());
            x.Add(mailbox);
            response = GetResponse();
            m = Regex.Match(response, reg);
        }
        IdleResume();
        return x.ToArray();
    }
