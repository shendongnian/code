    string myText = "sample text...";
    string formattedText = String.Empty;
    foreach(char c in myText)
    {
        if(Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
            formattedText += c;
    }
