    MediaQuery query = new MediaQuery();
    Dictionary<string, string> results = query.QueryFile(@"C:\text.mov");
    string videoBitRate;
    
    if (results.TryGetValue("Video/Bit_rate", out videoBitRate) == false)
    { 
       throw new Exception("Video bit rate not found"); 
    }
    else
    {
       // Do whatever you want with this....
       Console.writeline("Video bitrate:" + videoBitRate);
    }
 
