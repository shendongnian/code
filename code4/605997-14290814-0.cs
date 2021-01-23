    var sb = new StringBuilder();
    using (var sr = new StreamReader("inputFileName"))
    {
        string line;
        do
        {
            line = sr.ReadLine();
            sb.AppendLine(line);
        } while (!line.Contains("<Sim Properties>"));
                    
        sb.Append(myText);
        sb.Append(sr.ReadToEnd());
    }
    
    using (var sr = new StreamWriter("outputFileName"))
    {
        sr.Write(sb.ToString());
    }
