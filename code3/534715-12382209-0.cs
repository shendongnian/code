            public string convertBackToPrint(string oldText)
            {
                string newText = oldText.Replace(",", "");
                newText = newText.Replace("*", "å");
                newText = newText.Replace(">", "ä");
                newText = newText.Replace("[", "ö");
                newText = newText.Replace('\'', '.');
                newText = newText.Replace('1', ',');
                newText = newText.Replace('5', '?');
                newText = newText.Replace('6', '!');
                newText = newText.Replace('3', ':');
                newText = newText.Replace('7', '=');
                newText = newText.Replace('4', '+');
                newText = newText.Replace('9', '*');
                newText = newText.Replace('=', 'é');
    
                var numberMatcher = new Regex(@"#\w+");
                var firstMatch = numberMatcher.Match(newText);
                string alteredMatch = convertToNum(firstMatch.ToString());
                string yourNewText = numberMatcher.Replace(newText, alteredMatch);
    
                return yourNewText;
            }
    
            private string convertToNum(string oldText)
            {
                string newText = "";
    
                newText = oldText.Replace("a", "1");
                newText = newText.Replace("b", "2");
                newText = newText.Replace("c", "3");
                newText = newText.Replace("d", "4");
                newText = newText.Replace("e", "5");
                newText = newText.Replace("f", "6");
                newText = newText.Replace("g", "7");
                newText = newText.Replace("h", "8");
                newText = newText.Replace("i", "9");
                newText = newText.Replace("j", "0");
                newText = newText.Replace("#", "");
    
                return newText;
            }
