    public static class ListExtensions
    {
        public static List<string> TrimList(this List<string> list)
        {
            Contract.Requires(list != null, "Cannot trim a null list reference");
        
            List<string> listCopy = list.ToList();
            Action<int> RemoveItem = index =>
            {
                if (string.IsNullOrEmpty(listCopy[index]) || string.IsNullOrWhiteSpace(listCopy[index]))
                {
                    listCopy.RemoveAt(index);
                }
            };
            if (listCopy.Count > 0)
            {
                RemoveItem(0);
                if (listCopy.Count > 1)
                {
                    RemoveItem(listCopy.Count - 1);
                }
            }
            return listCopy;
        }
    }
