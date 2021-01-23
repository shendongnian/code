            // assumption is that patterns contains a list of valid Regex expressions
            int i = 0;
            var mapOfGroupNameToPattern = patterns.ToDictionary(pattern => "Pattern" + (i++));
            match = Regex.Match(input, string.Join("|", mapOfGroupNameToPattern.Select(x => "(?<" + x.Key + ">" + x.Value + ")")));
            if (match.Success)
            {
                foreach (var pattern in mapOfGroupNameToPattern)
                {
                    if (match.Groups[pattern.Key].Captures.Count > 0)
                    {
                        // this is the pattern that was matched
                        return pattern.Value;
                    }
                }
            }
