     public class SerializableDynamicObjectComparer: IComparer
    {
        private readonly List<KeyValuePair<string, bool>> sortCriteria = new List<KeyValuePair<string, bool>>();
        private readonly TypeAccessor accessor;
        public SerializableDynamicObjectComparer(IEnumerable<string> criteria)
        {
            foreach (var criterium in criteria)
            {
                string[]  sortCriterium = criterium.Split('.');
                this.sortCriteria.Add(new KeyValuePair<string, bool>(sortCriterium[0],
                                                                     sortCriterium.Length == 0
                                                                         ? sortCriterium[1].ToUpper() == "ASC"
                                                                         : false));
            }
            this.accessor = TypeAccessor.Create(typeof (IDynamicMetaObjectProvider));
        }
        public int Compare(object x, object y)
        {
            for(int i=0; i< this.sortCriteria.Count; i++)
            {
                string fieldName = this.sortCriteria[i].Key;
                bool isAscending = this.sortCriteria[i].Value;
                int result = Comparer.Default.Compare(this.accessor[x, fieldName], this.accessor[y, fieldName]);
                if(result != 0)
                {
                    //If we are sorting DESC, then return the -ve of the default Compare result
                    return isAscending ? result : -result;
                }
            }
            //if we get here, then objects are equal on all sort criteria.
            return 0;
        }
    }
