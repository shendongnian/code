    private string createTable(string[] cols, string[][] values)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(@"\begin{table}[ht]");
        sb.AppendLine(@"\centering");
        // Assuming four columns.
        sb.AppendLine(@"\begin{tabular}{c c c c}");
        sb.AppendLine(@"\hline\hline");
        // Column headers.
        bool first = true;
        foreach (string col in cols)
        {
            if (!first)
                sb.Append(" & ");
            sb.Append(col);
            first = false;
        }
        sb.AppendLine();
        sb.AppendLine(@"\hline");
        foreach (string[] rowCells in values)
        {
            first = true;
            foreach (string cell in rowCells)
            {
                if (!first)
                    sb.Append(" & ");
                sb.Append(cell);
                first = false;
            }
            sb.AppendLine(@" \\");
        }
        sb.AppendLine(@"\hline");
        sb.AppendLine(@"\end{tabular}");
        sb.AppendLine(@"\end{table}");
        return sb.ToString();
    }
