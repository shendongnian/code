    const int AllowedCharactersPerLine = 16;
    string example = "this is a very long string that we want to divide to fit to several lines";
    string StringWithRows = "";
    int n = 0;
    for(int i = 0; i < example.Length; i++)
    {
       StringWithRows += example.Substring(i, 1);
       n++;
       if (n == AllowedCharactersPerLine)
       {
           n = 0;
           StringWithRows += Environment.NewLine;
       }
    }    
