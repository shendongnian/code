    for(int i=0;i<20000;i++)
        string Lines = " 20000 Data lines one by one appended"+System.Environment.NewLine;
        Message.AppendLine(Lines);
        Event( EventName, Message.ToString());
    
        Client:
        Void FileWrite(String Message)
        {
         //Stream Writer to write the data into file.
         writeToFile.Write(Message);
         writeToFile.Flush();
        }
