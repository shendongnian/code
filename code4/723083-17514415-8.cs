    string[] ExtractColumns(string line) {
        int index = line.IndexOf("]");
        string firstColumn = line.Substring(0, index + 1);
        string[] lastTwoColumns = line.Substring(index + 2).Split(' ');
        return new string[] { firstColumn, lastTwoColumns[1], lastTwoColumns[2] };
    }
