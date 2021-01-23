    class Item
    {
        public bool Gender { get; set; }
        public int Color { get; set; }
        public string Type { get; set; }
        public string[] GetKeyWords()
        {
            // Return properties as array of key words.
            // You can cache the result for future use.
            return default(string[]);
        }
    }
