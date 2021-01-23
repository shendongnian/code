    myList.Sort((x, y) => ExtractNumber(x).CompareTo(ExtractNumber(y)));
           
    // note I've changed the use of int's to doubles since you seem to be working with fractions
    static double ExtractNumber(string text)
            {
                var fields = text.Split(',');
                double value;
                if (fields.Length == 0
                    || !double.TryParse(fields[0], out value))
                {
                    return 0; // as in your original code, missing/unparseable values get treated as 0
                }            
    
                return value;
            }
