        String outputFile = this.outputTxt.Text;
        String inputFolder = this.inputTxt.Text;
        StringBuilder files = new StringBuilder();
        foreach (String f in Directory.EnumerateFiles(inputFolder))
        {
            files.Append(f).Append("+");
        }
        files = files.Remove(file.Length-1, 1); // Remove trailing plus
        files.Append(" ").Append(outputFile);      
        using (var proc = Process.Start("cmd.exe", "/C copy " + files.ToString()))
        {
            proc.WaitForExit();
        }
