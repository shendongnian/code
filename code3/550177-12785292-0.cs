       string content = "\"bar\",\"foo, bar\",\"18\",\"07/09/2012 02:08:16\",\"payments, recent\",\"payments, all\"";
        content = content.Replace("\",\"", "~");
        content = content.Replace(",", ""); // Safe to remove commas now.
        content = content.Replace("\"", ""); // Get rid of left over double quotes.
        string[] values = content.Split(new[] { '~' });
