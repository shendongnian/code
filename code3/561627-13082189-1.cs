    public static class TableHandler {
        ICollection<Dictionary<string, Delegate>> tables = new List<Dictionary<string, Delegate>>();
         
        public void Add(Dictionary<string, Delegate> item) 
        {
            tables.Add(item);
        }
        public void Clear()
        {
            foreach (var item in tables) item.Clear();
            tables.Clear();
        }
    }
