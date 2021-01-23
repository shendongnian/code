    string path = @"c:\dev\text.txt"; //your path here
    string[] lines = File.ReadAllLines(path);
    double[] doubles = new double[2];
    for (int i = 0; i < doubles.Length; i++)
    {
        double d;
        if (double.TryParse(lines[i], out d))
            doubles[i] = d;
    }
