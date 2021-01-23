     public static void ConvertDecimalToInts(this string[] values)
        {
            for (int i = 0; i < values.Count(); i++)
            {
                decimal newvalue;
                if (Decimal.TryParse(values[i], out newvalue))
                {
                    values[i] = Decimal.ToInt32(newvalue).ToString();
                }
            }    
        }
    
