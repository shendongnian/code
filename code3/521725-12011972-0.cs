    public static class CharArrayExtension
    {
        public static char[,] FormatMatrix(this char[][] matrix)
        {
            int TotalColumns = matrix.Length;
            int TotalLines = 0;
            //Get the longest line of the current matrix
            for (int column = 0; column < TotalColumns; column++)
            {
                int line = matrix[column].Length;
                if (line > TotalLines)
                    TotalLines = line;
            }
            //Instantiate the resulting matrix
            char[,] Return = new char[TotalColumns, TotalLines];
            Return.Initialize();
            //Retrieve values from the current matrix
            for (int CurrentColumn = 0; CurrentColumn < TotalColumns; CurrentColumn++)
            {
                int MaxLines = matrix[CurrentColumn].Length;
                for (int CurrentLine = 0; CurrentLine < MaxLines; CurrentLine++)
                {
                    Return[CurrentColumn, CurrentLine] = matrix[CurrentColumn][CurrentLine];
                }
            }
            return Return;
        }
    }
