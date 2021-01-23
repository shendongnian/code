    public static class ListExtensions
    {
        public static List<string> TrimList(this List<string> list)
        {
            int listCount = list.Count;
            List<string> listCopy = list.ToList();
            List<string> result = list.ToList();
    
            // This will encapsulate removing an item and the condition to remove it.
            // If it removes the whole item at some index, it return TRUE.
            Func<int, bool> RemoveItemAt = index =>
            {
                bool removed = false;
    
                if (string.IsNullOrEmpty(listCopy[index]) || string.IsNullOrWhiteSpace(listCopy[index]))
                {
                    result.Remove(result.First(item => item == listCopy[index]));
                    removed = true;
                }
    
                return removed;
            };
    
            // This will encapsulate the iteration over the list and the search of 
            // empty strings in the given list
            Action RemoveWhiteSpaceItems = () =>
            {
                int listIndex = 0;
    
                while (listIndex < listCount && RemoveItemAt(listIndex))
                {
                    listIndex++;
                }
            };
    
            // Removing the empty lines at the beginning of the list
            RemoveWhiteSpaceItems();
    
            // Now reversing the list in order to remove the 
            // empty lines at the end of the given list
            listCopy.Reverse();
            result.Reverse();
                
            // Removing the empty lines at the end of the list
            RemoveWhiteSpaceItems();
                
            // Reversing again in order to recover the right list order.
            result.Reverse();
    
            return result;
        }
    }
