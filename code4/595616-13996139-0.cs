    Process process = new Process();
    process.StartInfo.FileName = "\"" + fullFileName + "\"";
    process.StartInfo.Arguments = args;
    //...
    process.Start();
    
