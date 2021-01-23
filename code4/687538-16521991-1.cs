    class IndexReceiver
    {
        public string Name { get; set; }
        public int Index { get; set; }
        
        public static implicit operator IndexReceiver(string name)
        {
            return new IndexReceiver() { Name = name };
        }
    }
