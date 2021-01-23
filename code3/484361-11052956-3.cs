    public string AutoComplete(string sentence, string selection)
    {
        if (String.IsNullOrWhiteSpace(sentence))
        {
            throw new ArgumentException("sentence");
        }
        if (String.IsNullOrWhiteSpace(selection))
        {
            // alternately, we could return the original sentence
            throw new ArgumentException("selection");
        }
        
        // TrimEnd might not be needed depending on how your UI / suggestion works
        // but in case the user can add a space at the end, and still have suggestions listed
        // you would want to get the last index of a space prior to any trailing spaces
        int index = sentence.TrimEnd().LastIndexOf(' ');
        if (index == -1)
        {
            return selection;
        }
        return sentence.Substring(0, index + 1) + selection;
    }
