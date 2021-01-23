    private List finalColorList()
    { 
        string[] allColors = Enum.GetNames(typeof(System.Drawing.KnownColor));
        string[] systemEnvironmentColors = 
            new string[(
            typeof(System.Drawing.SystemColors)).GetProperties().Length];
    
        int index = 0;
    
        foreach (MemberInfo member in (
            typeof(System.Drawing.SystemColors)).GetProperties())
        {
            systemEnvironmentColors[index ++] = member.Name;            
        }
    
        List finalColorList =  new List();
                
        foreach (string color in allColors)
        {
            if (Array.IndexOf(systemEnvironmentColors, color) < 0)
            {
                finalColorList.Add(color);
            }                           
        }
        return finalColorList;
    }
