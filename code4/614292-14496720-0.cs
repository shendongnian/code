    public static class tmpExtensions
        {
        public static System.Collections.Hashtable ToHashTable(this List<tmp> t, bool option)
        {
            if (t.Count < 1)
                return null;
            
            System.Collections.Hashtable hashTable = new System.Collections.Hashtable();
            if (option)
            {
                t.ForEach(q => hashTable.Add(q.Id + q.Index,q.Name+q.LName));
            }
            else
            {
                t.ForEach(q => hashTable.Add(q.Id,q.Index));
            }
            return hashTable;
        }
    }
