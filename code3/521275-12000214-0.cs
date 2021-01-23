    public ShortMessageCollection ParseMessages(string input)
    {
        ShortMessageCollection messages = new ShortMessageCollection();
        Regex r = new Regex(
            @"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n",
            RegexOptions.Multiline);
        Match m = r.Match(input);
        while (m.Success)
        {
            ShortMessage msg = new ShortMessage();
            msg.Index = m.Groups[1].Value;
            msg.Status = m.Groups[2].Value;
            msg.Sender = m.Groups[3].Value;
            msg.Alphabet = m.Groups[4].Value;
            msg.Sent = m.Groups[5].Value;
            msg.Message = m.Groups[6].Value;
            messages.Add(msg);
            m = m.NextMatch();
        }
        return messages;
    }
