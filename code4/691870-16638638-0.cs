      private void FunctionOne(string input)
            {
                var matches = new List<string>();
                string match = string.Empty;
                Boolean startRecording = false;
                foreach (char c in input)
                {
                    if (c.Equals(Convert.ToChar("<")))
                    {
                        startRecording = true;
                        continue;
                    }
    
                    if (c.Equals(Convert.ToChar(">")))
                    {
                        if (!string.IsNullOrEmpty(match))
                        {
                            matches.Add(match);
                            match = string.Empty;
                            startRecording = false;
                        }
                    }
    
                    if (startRecording)
                    {
                        match += c;
                    }
                }
            }
