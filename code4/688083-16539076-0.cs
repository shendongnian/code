    public string SortValue
    {
        get
        {
            return ((int)((MessageDate - new DateTime(1970, 1, 1)).TotalSeconds)).ToString("D12");
        }
    }
