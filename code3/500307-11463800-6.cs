    public static List<List<float[]>> splitList(List<float[]> locations, int nSize=30)  
    {        
        var list = new List<List<float[]>>(); 
 
        for (int i = 0; i < locations.Count; i += nSize) 
        { 
            list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i))); 
        } 
 
        return list; 
    } 
