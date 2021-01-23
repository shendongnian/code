    public static void RemoveTwo(List<string> strList)
    {
        if(strList.Count > 0)
            strList.RemoveAt(strList.Count-1);
        if(strList.Count > 0)
            strList.RemoveAt(strList.Count-1);
    }
