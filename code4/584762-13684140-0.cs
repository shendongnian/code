    var myFile = "C:\\PathToDirectory";//your folder
    bool doesExist = Directory.Exists(myFile);
    if (doesExist)
    {
        string content = File.ReadAllText(myFile + "\\myFile.txt");//your txt file
        string[] searchedText = new string[] { "ThisIsOkString", "ThisIsBadString" };
        foreach (string item in searchedText)
        {
            if (searchedText.Contains(item))
            {
                Console.WriteLine("Found {0}",item);
                break;
            }
        }
    }
