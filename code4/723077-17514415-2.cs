    string ExtractFirstColumn(line) {
        int index = line.IndexOf("]");
        string firstColumn = line.Substring(0, index + 1);
        return firstColumn;
    }
