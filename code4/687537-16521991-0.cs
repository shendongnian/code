    class IndexReceiver
    {
        public string Name { get; set; }
        public int Index { get; set; }
        
        public static explicit operator IndexReceiver(string name)
        {
            return new IndexReceiver() { Name = name };
        }
    }
