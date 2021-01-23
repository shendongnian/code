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
        
        return string.Format("{0:0.00} {1}B", result, sizes[i]);
    }
