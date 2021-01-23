    ResultData Parse(String value, ref Int32 index)
    {
        ResultData result = new ResultData();
        Index startIndex = index; // Used to get substrings
        while (index < value.Length) 
        {
            Char current = value[index];
        
            if (current == '(')
            {
                index++;
                result.Add(Parse(value, ref index));
                startIndex = index;
                continue;
            }
            if (current == ')')
            {
                // Push last result
               index++;
               return result;
            }
            
            // Process all other chars here
        }
        
        // We can't find the closing bracket
        throw new Exception("String is not valid");
    }
