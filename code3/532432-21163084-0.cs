     public string ToString(this string value)
            {
                if (value == null)
                {
                    value = string.Empty;
                }               
                else
                {
                    return value.Trim();
                }
            }
