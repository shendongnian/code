    public class SelectionCriteria<T>
        where T : class
    {
        public IList<T> EligibleList { get; private set; }
        public IList LookupList { get; private set; }
        public SelectionCriteria(IList lookupList, IList<T> eligibleList)
        {
            LookupList = lookupList;
            EligibleList = eligibleList;
        }
        
        public bool this[int index]
        {
            get
            {
                var element = LookupList[index];
                foreach (var item in EligibleList)
                {
                    if (item.Equals(element))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
