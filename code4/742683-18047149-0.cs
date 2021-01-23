    public static string[,] SplitResults(string[] input)
    {
        int columns = input[0].Split(',').Length;
        string[,] output = new string[input.Length, columns];
        for (int row = 0; row < input.Length; row++)
        {
            string[] split = input[row].Split(',');
            for (int column = 0; column < columns; column++)
            {
                output[row, column] = split[column];
            }
        }
        return output;
    }
