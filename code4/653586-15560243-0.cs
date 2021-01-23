    Dictionary<string, object> variables;
    private bool ReadAllVariablesFromDataFile(string[] lines)
    {
        int i = 0;
        while (i < lines.Length)
        {
            string line = lines[i];
            int oldI = i;
            i = ReadSingleVariable(i, lines);
        }
        return true;
    }
    private static bool IsDefinitionLine(string line)
    {
        return (line != null && line.TrimStart().StartsWith("#"));
    }
    private int ReadSingleVariable(int startIndex, string[] lines)
    {
        // TODO: Types other than matrix.
        OctaveVariable variable = new OctaveVariable();
        while (IsDefinitionLine(lines[startIndex]))
        {
            ProcessDefinitionLine(variable, lines[startIndex]);
            startIndex++;
        }
        if (!variable.IsInitialized)
        {
            return startIndex;
        }
        for (int i = 0; i < variable.Rows; i++)
        {
            ProcessDataLine(variable, lines[startIndex + i], i);
        }
        this.variables.Add(variable.Name, variable.Value);
        return startIndex + variable.Rows;
    }
    private static void ProcessDefinitionLine(OctaveVariable variable, string line)
    {
        string value = GetLineValue(line);
        switch (GetLineId(line))
        {
            case "name":
                variable.Name = value;
                variable.IsInitialized = true;
                break;
            case "rows":
                variable.Rows = int.Parse(value);
                break;
            case "columns":
                variable.Columns = int.Parse(value);
                break;
            default:
                break;
        }
    }
    private static void ProcessDataLine(OctaveVariable variable, string line, int rowIndex)
    {
        string[] values = line.Trim().Split(' ');
        double[] row = new double[variable.Columns];
        for (int i = 0; i < variable.Columns; i++)
        {
            variable.Value[rowIndex, i] = double.Parse(values[i]);
        }
    }
    private static string GetLineId(string line)
    {
        return line.Split(':').First().TrimStart('#').Trim().ToLowerInvariant();
    }
    private static string GetLineValue(string line)
    {
        string[] pair = line.Split(':');
        if (pair.Length < 2)
        {
            throw new ArgumentException("Invalid def line");
        }
        return pair[1].Trim();
    }
