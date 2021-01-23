    public class Category {
        private Dictionary<int, string> items = new Dictionary<int,, string>();
        
        public void Add(int id, string description) {
            if (GetId(description <> -1)) {
                // Entry with description already exists. 
                // Handle accordingly to enforce uniqueness if required.
            } else {
                items.Add(id, description);
            }
        }
        public string GetDescription(int id) {
            return items[id];
        }
        public int GetId(string description) {
            var entry = items.FirstOrDefault(x => x.Value == description);
            if (entry == null) 
                return -1;
            else
                return entry.Key;
        }
    }
