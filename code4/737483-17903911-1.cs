    string str = "http://stackoverflow.com/questions/ask/randomcrap.html";
    string final = RemoveAfterLastChar(str, '/');
    public string RemoveAfterLastChar(string input, char c)
    {
        var index = input.LastIndexOf(c);
        if (index != -1)
            return input.Substring(0, index + 1);
        else
            return input;
    }
  
