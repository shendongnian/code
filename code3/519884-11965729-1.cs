    public string FormatSize(long size)
    {
        double result = size;
    
        var sizes = new string[] { "", "K", "M", "G", "T", "P", "E" };
        
        int i = 0;
        while (result > 1000 && i < sizes.Length)
        {
            result /= 1000; // or 1024 if you want
            i++;
        }
        // EDIT: Optimized decimal places
        string format = "{0:0.00} {1}B"; // default: 2 decimals
        
        switch (sizes[i])
        {
            case "":
                format = "{0} B"; // no decimals for bytes
                break;
            case "K":
                format = "{0:0.0} KB"; // 1 decimal for KB
                break;
        }
        // /EDIT
        
        return string.Format(format, result, sizes[i]);
    }
