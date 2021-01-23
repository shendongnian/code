    string[] lines = File.ReadAllLines(file);
    using (StringWrite writer = new StringWriter(outputFile))
    {
        foreach (string line in lines)
        {
            string[] numParts = line.Split(' ');
            foreach(string number in numParts)
            {
                if(isNumber(number))
                   writer.Write(number + " True");
                else
                   writer.Write(number + "False");
            }
        }
    }
    public static bool isNumberValid(string Number)
    {
        int result;
        return Int32.TryParse(number, out result);
    }
