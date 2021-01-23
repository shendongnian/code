    string fullWeek = "MTWtFSs";
    string weekMask = "0100110";
    const char blankChar = '-';
    int totalChars = fullWeek.Length;
    StringBuilder result = new StringBuilder();
    for (int index = 0; index < totalChars; index++)
    {
        if (weekMask[index] == '1')
        {
            result.Append(fullWeek[index]);
        }
        else
        {
            result.Append(blankChar);
        }
    }
    Console.WriteLine(result);
