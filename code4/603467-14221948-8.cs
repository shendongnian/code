    public static class SelectionCriteriaExtensions
    {
        public static bool IsLookupItemEligible<T>(this SelectionCriteria<T> set, int index)
            where T : class
        {
            var element = set.LookupList[index];
            foreach (var item in set.EligibleList)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
    }
