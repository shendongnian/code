    public List<string> GetEmailList()
    {
        return dt.AsEnumerable().Select(r => r[0].ToString()).ToList();
    }
 
