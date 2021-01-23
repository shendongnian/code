        object GetValue(object value, string name)
        {
            return value.GetType().GetProperty(name).GetValue(value, null);
        }
        public List<object> SortContent(List<object> listToSort, IEnumerable<KeyValuePair<string, SortDirection>> sortInfos)
        {
            IOrderedEnumerable<object> sortedList = null;
            foreach (KeyValuePair<string, SortDirection> column in sortInfos)
            {
                Func<object, object> sort = x => GetValue(x, column.Key);
                
                bool desc = column.Value == SortDirection.Descending;
                if (sortedList == null)
                    sortedList = desc ? listToSort.OrderByDescending(sort) : listToSort.OrderBy(sort);
                else
                    sortedList = desc ? sortedList.ThenByDescending(sort) : sortedList.ThenBy(sort);
            }
            return sortedList.ToList();
        }
