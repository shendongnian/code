    string[] lines = File.ReadAllLines(file);
    using (StringWriter writer = new StringWriter(outputFile))
    {
        foreach (string line in lines)
        {
            string[] numParts = line.Split(' ');
            foreach(string number in numParts)
            {
                if(isNumberValid(number))
                   writer.Write(number + " True");
                else
                   writer.Write(number + " False");
            }
        }
    }
    public static bool isNumberValid(string Number)
    {
        int result;
        return Int32.TryParse(Number, out result);
    }
