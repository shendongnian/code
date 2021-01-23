    private class WindowLookup
    {
        public string LookupName { get; private set; }
        public List<IntPtr> MatchedChildren { get; private set; }
        public int Depth { get; set; }
        public int MaxDepth { get; set; }
        public WindowLookup(string lookup, int maxdepth)
        {
            this.MatchedChildren = new List<IntPtr>();
            this.LookupName = lookup;
            this.MaxDepth = maxdepth;
            if (this.MaxDepth > 0)
                this.MaxDepth++; //account for the depth past the parent control.
            this.Depth = 0;
        }
    }
