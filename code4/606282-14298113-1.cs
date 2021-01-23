    using(var writer = File.AppendText("fileName"))
    {
        writer.AutoFlush = true;
        foreach(string line in lines)
            writer.WriteLine(line);
    }
