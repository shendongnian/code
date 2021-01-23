    while (newPort.BytesToRead > 0)
     {
         received = ReadLine(newPort);
    
         response.Add(string.Format("{0}{1}", received, System.Environment.Newline);
     }
