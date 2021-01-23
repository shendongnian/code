    var r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""",
                      RegexOptions.Compiled);
    var messages = new ShortMessageCollection();
    using (var sw = new StringReader(input))
    {
        string currentLine = sw.ReadLine();
        while (currentLine != null)
        {
            var m = r.Match(currentLine);
            if (m.Success)
            {
                // read the first line of the message
                string message = string.Empty;
                currentLine = sw.ReadLine();
                // Append any extra lines to our message, unless it's a new record
                while (currentLine != null && !r.IsMatch(currentLine))
                {
                    message += Environment.NewLine;
                    message += currentLine;
                    currentLine = sw.ReadLine();
                }
                messages.Add(new ShortMessage
                                 {
                                     Index = m.Groups[1].Value,
                                     Status = m.Groups[2].Value,
                                     Sender = m.Groups[3].Value,
                                     Alphabet = m.Groups[4].Value,
                                     Sent = m.Groups[5].Value,
                                     Message = message,
                                 });
            }
            else
            {
                // TODO: Log that a line didn't match
                // it could be empty or otherwise invalid
                currentLine = sw.ReadLine();
            }
        }
    }
