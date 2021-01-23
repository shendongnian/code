    string textToPAss = ReplaceInvalidCharacters(yourTextbox.Text);
    public string ReplaceInvalidCharacters(string toReplace)
    {
       toReplace = toReplace.Replace("€","");
       //similarly do for all others unwanted characters
        return toReplace;
    }
