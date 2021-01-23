    string date;
    string subject;
    string from;
    string read;
    string to;
    foreach (string line in myString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
    {
        if(line.Contains("Subject="))
             subject = line;
        else if (line.Contains("From="))
             from = line;
        //......
    }
