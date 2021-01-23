    public int? ConvertStringToNumber(String TheString)
            {
    
                // Uninitialized
                int Retval;
    
                if (TheString.Length > 0)
                {
    
                    // We have a valid string
    
                    if (Int32.TryParse(TheString, out Retval))
                    {
    
                        // We have a valid Number
                        return Retval;
    
                    }
    
                }
    
    
                // Return the number or null
    
                return null;
    
            }
