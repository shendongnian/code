    public static void ArrayList FindLongest(params ArrayList[] lists)
    {
        return lists == null 
            ? null
            : lists.OrderByDescending(x => x.Count).FirstOrDefault();
    }
