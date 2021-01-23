    public string RemoveNamespace(string typename)
    {
        if(typename.Contains("<")
        {            
            var genericArguments = 
                typename.
                    // in reality, we need a substring before 
                    // first occurence of "<" and last occurence of ">"
                    SubstringBetween("<", ">").
                    Split(',').
                    Select(string.Trim).
                    Select(RemoveNamespace);
            return 
                RemoveNamespace(typename.SubstringBefore("<")) + 
                    "<" + 
                    string.Join(", ", genericArguments) + 
                    ">";
        }
        else
        {
            return typename.Trim().SubstringAfterLastOccurenceOf(".");
        }
    }
