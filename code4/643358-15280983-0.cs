    string dictionaryPath = @"C:\MyFile.ext";
    string dictionaryContent = string.empty;
    try // intercept file not exists, protected, etc..
    {
        dictionaryContent = File.ReadAllText(dictionaryPath);
    }
    catch (Exception exc)
    {
        // write error in log, or prompt it to user
        return; // exit from method
    }
    
    string[] dictionary = dictionaryContent.Split(new[] { "\r\n" }, StringSplitOptions.None);
    foreach (string entry in dictionary)
    {
        switch (entry)
        {
            case "[Copyright]":
                break;
            case "[Try]":
                break;
            default:
                break;
        }
    }
