    string emptyAnchor = "<a href=""#""></a>";
    string src = GetData();
    string[] splits = src.split(new string[]{"%%"}, StringSplitOptions.None);
    StringBuilder sb = new StringBuilder();
    //first entry is blank, set to 1
    int i = 1;
    while(i < splits.length)
    {
        string id = splits[i];
        //increment for data string
        i++;
        //prehaps use a StringReplaceFirstOccurrence function instead
        sb.Append(splits[i].Replace(emptyAnchor, GetDataFromID(id)));
        i++;
    }
    string output = sb.ToString();
