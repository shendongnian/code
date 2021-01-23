     static IEnumerable<string> GetListFromString(string stringToExtract)
        {
            var regex = new Regex(@"(?<=\[).*?(?=\])");
            foreach (Match match in regex.Matches(stringToExtract))
            {
                yield return match.Value;
            }
        }
