        private static List<Error> ParseErrors(string filepath)
        {
            Regex parser = new Regex(@"^(?<date>\w{3}\s\d{1,2}\s\d{1,2}(?::\d{1,2}){2}),[^\|]+\|ERROR\|[^:]+\s*(?<description>.+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string line = string.Empty;
            Match curMatch = null;
            var errorLog = new List<Error>();
            using (StreamReader sReader = new StreamReader(filepath))
            {
                while (!sReader.EndOfStream && (line = sReader.ReadLine()) != null)
                {
                    curMatch = parser.Match(line);
                    if (curMatch.Success)
                    {
                        errorLog.Add(new Error()
                        {
                            ID = errorLog.Count, /* not sure how you assign ids? */
                            Date = curMatch.Groups["date"].Value.Trim(),
                            Description = curMatch.Groups["description"].Value.Trim(),
                            ErrorType = sReader.ReadLine().Trim()
                        });
                    }
                }
            }
            return errorLog;
        }
