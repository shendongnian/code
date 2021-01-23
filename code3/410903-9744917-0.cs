    private void MultiPasteArrayGenerator()
        {
            string[] lines = null;
            if (Clipboard.GetText().Contains('='))
            {
                
            }
            else if (Clipboard.GetText().Contains(':'))             //Strips headers from skip tools run through Agent Toolbox
            {                
                string filterLabels = @"(?:\w+\s?)*\:(?:\s?)*";           //Set up RegEx statement
                List<string> replacedLine = new List<string>();
                List<string> brokenLines = new List<string>();
                lines = Regex.Split(Clipboard.GetText(), filterLabels);  //Divide text on clipboard into one string per line
                foreach (string line in lines)
                {
                    brokenLines.Add(line);
                }
                brokenLines.Remove("");
                string[] broken = brokenLines.ToArray();
                MultiPaste(broken);
            }
            else
            {
                lines = Regex.Split(Clipboard.GetText(), "\r\n");
                MultiPaste(lines);
            }
