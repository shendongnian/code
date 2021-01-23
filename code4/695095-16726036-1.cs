    string myText = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'";
    Regex reg = new Regex("\b[\"']\b");
    myText = reg.Replace(myText, "");
    string[] listOfWords = RemoveCharacters(myText);
    public string[] RemoveCharacters(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (Char.IsLetter(c) || Char.IsWhiteSpace(c) || c == '\'')
               sb.Append(c);
        }
    
        return sb.ToString().Split(' ');
    }
