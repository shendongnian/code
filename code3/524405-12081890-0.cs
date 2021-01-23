    public static string EmptyToNumber(this string input)
    {
        return (string.IsNullOrEmppty(input) ? "0" : input); 
    }
   
