        // Resolve Decimal Issues
        foreach (object Column in splitLine)
        {
            String CurrentColumn = Column.ToString();
            if (Regex.IsMatch(CurrentColumn, @"^[0-9]+(\.[0-9]+)?$"))
            {
                // If there's a decimal point, remove characters from the front
                // of the string to compensate for the decimal portion.
                int decimalPos = CurrentColumn.IndexOf(".");
                if (decimalPos != -1)
                {
                    CurrentColumn = CurrentColumn.Substring(CurrentColumn.Length - decimalPos);
                }
            }
             //Start re-joining the string
            newLine = newLine + CurrentColumn + "\t";
        }
