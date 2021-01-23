        private string ReplaceText(string originalText)
        {
            string replacedText = null;
            Regex regEx = new Regex("[your expression here]");
            Match match = regEx.Match(originalText);
            if (match.Success)
            {
                Group matchGroup = match.Groups[2];
                //[first part of original string] + [replaced text] + [last part of original string]
                replacedText =
                    $"{originalText.Substring(0, matchGroup.Index)}[Your replaced string here]{originalText.Substring(matchGroup.Index + matchGroup.Length)}";
            }
            else
                replacedText = originalText;
            return replacedText;
        }
