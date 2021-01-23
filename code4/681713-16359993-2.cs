    int index = 0;                                                  // Starting at first character
    char[] separators = "-/".ToCharArray();
    while (index < input.Length) {
        index = input.IndexOfAny(separators, index);              // Find next separator
        if (index < 0) break;
        Debug.WriteLine((index+1).ToString() + ": " + input[index]);
        index++;
    }
