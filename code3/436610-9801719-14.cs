    class Link
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public Link(string from, string to)
        {
            this.From = from;
            this.To = to;
        }
    }
    
