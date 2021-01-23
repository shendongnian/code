      private void FunctionOne(string input)
            {
                   var matches = new List<string>();
            var match = new StringBuilder();
            Boolean startRecording = false;
            foreach (char c in input)
            {
                if (c.Equals('<'))
                {
                    startRecording = true;
                    continue;
                }
                if (c.Equals('>'))
                {
                        matches.Add(match.ToString());
                        match = new StringBuilder();
                        startRecording = false;
                }
                if (startRecording)
                {
                    match.Append(c);
                }
            }
            }
