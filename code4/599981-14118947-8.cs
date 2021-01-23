    public static bool CheckDate(string number, out Patterns patterns)
    {
        patterns = null;
        string new_number = number.ToString();
        if (new_number.Length == 8)
        {
           Patterns = new Patterns
           {
               YYYY = new_number.Substring(0, 4),
               MM = new_number.Substring(4, 2),
               DD = new_number.Substring(6, 2)
           }
           return true;
        }
        else
        {
            return false;
        }
    }
