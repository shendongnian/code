    // Read all lines in memory (Could be optimized, but for this example let's go with a small file)
    string[] lines = File.ReadAllLines(file);
    // Open the output file
    using (StringWriter writer = new StringWriter(outputFile))
    {
        // Loop on every line loaded from the input file
        // Example "1234 ABCD 456 ZZZZ 98989"
        foreach (string line in lines)
        {
            // Split the current line in the wannabe numbers
            string[] numParts = line.Split(' ');
            // Loop on every part and pass to the validation
            foreach(string number in numParts)
            {
                // Write the result to the output file
                if(isNumberValid(number))
                   writer.WriteLine(number + " True");
                else
                   writer.WriteLine(number + " False");
            }
        }
    }
    // Receives a string and test if it is a Int32 number
    public static bool isNumberValid(string Number)
    {
        int result;
        return Int32.TryParse(Number, out result);
    }
