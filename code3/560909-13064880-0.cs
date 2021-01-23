    string FileToRead = File.ReadAllText("Path");
    
    string GetContent(string StartAt, string EndAt, bool LastIndex)
    {
    string ReturnVal;
    
    if(LastIndex)
    {
    ReturnVal = FileToRead.Remove(FileToRead.IndexOf(StartAt), FileToRead.IndexOf(EndAt));
    Return ReturnVal;
    }
    else
    { 
    ReturnVal = FileToRead.Remove(FileToRead.LastIndex(StartAt), FileToRead.LastIndex(EndAt));
    Return ReturnVal;
    }
    }
