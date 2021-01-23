     public static string GetColumnName(string cellReference)
            {
                // Create a regular expression to match the column name portion of the cell name.
                Regex regex = new Regex("[A-Za-z]+");
                Match match = regex.Match(cellReference);
                return match.Value;
            }
