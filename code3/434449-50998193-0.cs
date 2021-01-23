    public static bool ToBoolean(this string input)
            {
                //Account for a string that does not need to be processed
                if (string.IsNullOrEmpty(input))
                    return false;
    
                return (input.Trim().ToLower() == "true") || (input.Trim() == "1");
            }
