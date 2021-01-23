    public string QuoteFormat(object val)
    {
        if(val != null) {
            // This is fine if there is an additional requirement to double existing quotes
            if(val == typeof(string))
                val = (val as string).Replace("\"" , "\"\"");
            
            // if you are using dates and the default format is fine, then this will work.
            // otherwise I would suggest formatting the date before passing in and perhaps
            // changing the parameter to string
            return string.Format("\"{0}\"" , val);
        } else {
            return "";
        }
    }
