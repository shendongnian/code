    public DeletedLastStringComparer : Comparer<string>
    {
        private const string Deleted = "_Deleted";
        public override int Compare(string x, string y)
        {
            var xDeleted = x.EndsWith(Deleted);
            var yDeleted = y.EndsWith(Deleted);
            if (xDeleted ^ yDeleted)
            {
                if (xDeleted)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                return StringComparer.Ordinal(x, y);
            }
        }
    }
