    string buffer = string.Empty;
    while(!process.HasExited)
    {
        string line = process.Stream.ReadLine();
        if (line != null)
            buffer += Enviorment.Newline + line
    }
    
    // Do stuff without put here
    Console.Write(buffer);
