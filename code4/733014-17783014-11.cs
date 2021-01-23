    WineCellar : IEquatable<string>
    {
        ...
        public bool Equals(string other)
        {
            return other.Equals(this.wine, StringComparison.Ordinal);
        }
    }
