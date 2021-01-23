        object GetValue(object value, string name)
        {
            return value.GetType().GetProperty(name).GetValue(value, null);
        }
        public List<object> SortContent(List<object> listToSort, Tuple<string, SortDirection>[] sortInfos)
        {
            if (sortInfos == null || sortInfos.Length == 0)
                 return listToSort;
            IOrderedEnumerable<object> sortedList = null;
            foreach (var column in sortInfos)
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
