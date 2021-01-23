        private Dictionary<string,string> ParseCommentVariables(string contents)
        {
            Dictionary<string,string> variables = new Dictionary<string,string>();
            Regex commentParser = new Regex(@"<!--.+?-->", RegexOptions.Compiled);
            Regex variableParser = new Regex(@"\b(?<name>[^:]+):\s*""(?<value>[^""]+)""", RegexOptions.Compiled);
            var comments = commentParser.Matches(contents);
            foreach (Match comment in comments)
                foreach (Match variable in variableParser.Matches(comment.Value))
                    if (!variables.ContainsKey(variable.Groups["name"].Value))
                        variables.Add(variable.Groups["name"].Value, variable.Groups["value"].Value);
            return variables;
        }
