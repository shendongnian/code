    // Resolve Decimal Issues
    foreach (object Column in splitLine)
    {
        String CurrentColumn = Column.ToString();
        if (CurrentColumn.Contains('.'))
            {
                // Count how many numbers AFTER a decimal
                int decimalLength = CurrentColumn.split('.')[1].Length;
                if (decimalLength >= 1)
                {
                    // Remove this amount of places from the start of the string
                    CurrentColumn = CurrentColumn.Substring(CurrentColumn.Length - decimalLength);
                }
            }
             //Start re-joining the string
            newLine = newLine + CurrentColumn + "\t";
        }
