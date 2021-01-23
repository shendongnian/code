    string results = "";
    while (!process.StandardOutput.EndOfStream)
    {
        results += process.StandardOutput.ReadLine();
    }
    return results;
