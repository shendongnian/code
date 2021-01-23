    public static Int32? Parse(this String s, Int32? defaultValue = null)
    {
        Int32 temp;
        return !Int32.TryParse(s, out temp)
            ? defaultValue
            : temp;
    }
    
    string validString = "1";
    int? parsed = validString.Parse(); //1
    int? failParsed = "asdf".Parse(9); //9
