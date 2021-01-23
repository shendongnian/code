    void Main()
    {
        string test = "123ABCD123";  // String to change
        string rep = "XYZ";          // String to replace
        string find = "123";         // Replacement string
        bool searchStart = true;     // Flag for checkbox startswith 
        bool searchEnd = true;       // Flag for checkbox endswith
        bool caseInsensitive = true; // Flag for case type replacement
        string result = test;         
        int pos = -1;
        int lastPos = -1;
        
        if(caseInsensitive == true)
        {
            pos = test.IndexOf(find, StringComparison.InvariantCultureIgnoreCase);
            lastPos = test.LastIndexOf(find, StringComparison.InvariantCultureIgnoreCase);
        }
        else
        {
            pos = test.IndexOf(find, StringComparison.Ordinal);
            lastPos = test.LastIndexOf(find, StringComparison.Ordinal);
        }
        
        result = test;
        if(pos == 0 && searchStart == true)
        {
            result = rep + test.Substring(find.Length);
        }
        if(lastPos != 0 && lastPos != pos && lastPos + find.Length == test.Length && searchEnd == true)
        {
            result = result.Substring(0, lastPos) + rep;
        }
        Console.WriteLine(result);
    }
    
