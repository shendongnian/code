    Encoding encodingOfChoice = Encoding.UTF8;
    byte[] bytes = encodingOfChoice.GetBytes(text);
    
    using (StreamWriter sw = new StreamWriter("c:\\folder\\folder.csv", 
            false, encodingOfChoice))
    {
        sw.Write(result);
    }
