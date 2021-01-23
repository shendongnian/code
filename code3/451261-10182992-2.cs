    public static List<UrlText> MergeLists(List<UrlText> listAdmin, List<UrlText> listUser)
    {
        List<UrlText> result = new List<UrlText>();
        foreach (UrlText myMenuItem in listAdmin)
        {
            result.Add(myMenuItem);
        }
        foreach (UrlText myMenuItem in listUser)
        {
            if (!result.Contains(myMenuItem))
                result.Add(myMenuItem);
        }
        return result;
    }
