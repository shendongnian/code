    public static int GetMaxForFile(int i) 
    { 
        string path = GetPath(i); 
    
        string line; 
        int max = 0;
     
        using (StreamReader reader = File.OpenText(path)) 
        { 
            while ((line = reader.ReadLine()) != null) 
            { 
                max = Math.Max(max, line.Max(t => int.Parse(t)));
            }
        } 
        return max;
    } 
