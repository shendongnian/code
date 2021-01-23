    public static class LookupItemListExtensions
    {
        public static void Add(this List<LookupItem> lookupItemList, int param1, int param2, float param3, float param4)
        {
            lookupItemList.Add(new LookupItem(param1, param2, param3, param4));
        }
    }
