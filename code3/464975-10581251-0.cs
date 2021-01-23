        public static List<Error> ParseErrors(string filepath)
        {
            //separated the two regex
            Regex dateRegex = new Regex(@"^\w{3}\s\d{2}\s\d{2}:\d{2}:\d{2}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex errorRegex = new Regex(@"((?<type>System.*?Exception):\s(?<description>.*\.))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string CurrentLine = string.Empty;
            string NextLine = string.Empty;
            List<Error> errorLog = new List<Error>();
            using (StreamReader sReader = new StreamReader(filepath))
            {
                while (!sReader.EndOfStream && (CurrentLine = sReader.ReadLine()) != null)
                {
                    
                    if (CurrentLine.Contains("|ERROR|"))
                    {
                        
                        Match DateMatch = dateRegex.Match(CurrentLine);
                        Match ErrorMatch = errorRegex.Match(CurrentLine);
                        string date = DateMatch.Groups[0].Value.Trim();
                        string errorType = string.Empty;
                        string description = string.Empty;
                        //Check if error type and description is residing in the current line, otherwise, check at the next line
                        if (!ErrorMatch.Groups["type"].Value.Equals("") && !ErrorMatch.Groups["description"].Value.Equals(""))
                        {
                            errorType = ErrorMatch.Groups["type"].Value.Trim();
                            description = ErrorMatch.Groups["description"].Value.Trim();
                        }
                        else
                        {
                            NextLine = sReader.ReadLine();
                            ErrorMatch = errorRegex.Match(NextLine);
                            errorType = ErrorMatch.Groups["type"].Value.Trim();
                            description = ErrorMatch.Groups["description"].Value.Trim();
                        }
                        Error NewError = new Error();
                        NewError.Date = date;
                        NewError.ErrorType = errorType;
                        NewError.Description = description;
                        //a bit lazy with the regex, just take the first sentence of the description if it has multiple sentences.
                        if (NewError.Description.Contains(". "))
                            NewError.Description = NewError.Description.Substring(0, NewError.Description.IndexOf(". "));
                        // Do not add if it's a custom exception.
                        if(!NewError.Description.Equals("") && !NewError.Description.Equals(""))
                            errorLog.Add(NewError);
                    }
                }
            }
            return errorLog;
        }
