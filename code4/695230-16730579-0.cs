    string patternClassName = @"(?<=class\s)\s*\S*";
    string patternClassConstructor = @"(?<=public\s)\s*\S*";
    private string Change(string source, string newName)
            {
                string changeClassNameResult = Regex.Replace(source, patternClassName, newName, RegexOptions.IgnoreCase);
                
                Match match = new Regex(patternClassName).Match(source);
    
                if (match.Success)
                {
                    return Regex.Replace(changeClassNameResult, patternClassConstructor + match.Value + "(", newName, RegexOptions.IgnoreCase);
                }
                else
                {
                    return changeClassNameResult;
                }
            }
