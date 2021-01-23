    class WineComparer : EqualityComparer<Wine>
    {
        [Flags]
        public Enum WineComparison
        {
            Name = 1,
            Vineyard= 2,
            Colour = 4,
            Region = 8,
            Variety = 16,
            All = 31
        }
        private readonly WineComparison comparison;
        public WineComparer()
            : this WineComparer(WineComparison.All)
        {
        }
        public WineComparer(WineComparison comparison)
        {
            this.comparison = comparison;
        }
        public override bool Equals(Wine x, Wine y)
        {
            if ((this.comparison & WineComparison.Name) != 0
                && !x.Name.Equals(y.Name))
            {
                return false;
            }
            if ((this.comparison & WineComparison.Vineyard) != 0
                && !x.Vineyard.Equals(y.Vineyard))
            {
                return false;
            }
            if ((this.comparison & WineComparison.Region) != 0
                && !x.Region.Equals(y.Region))
            {
                return false;
            }
            if ((this.comparison & WineComparison.Colour) != 0
                && !x.Colour.Equals(y.Colour))
            {
                return false;
            }
            if ((this.comparison & WineComparison.Variety) != 0
                && !x.Variety.Equals(y.Variety))
            {
                return false;
            }
            return true;
        }
        public override bool GetHashCode(Wine obj)
        {
            var code = 0;
            if ((this.comparison & WineComparison.Name) != 0)
            {
                code = obj.Name.GetHashCode();
            }
            if ((this.comparison & WineComparison.Vineyard) != 0)
            {
                code = (code * 17) + obj.Vineyard.GetHashCode();
            }
            if ((this.comparison & WineComparison.Region) != 0)
            {
                code = (code * 17) + obj.Region.GetHashCode();
            }
            if ((this.comparison & WineComparison.Colour) != 0)
            {
                code = (code * 17) + obj.Colour.GetHashCode();
            }
            if ((this.comparison & WineComparison.Variety) != 0)
            {
                code = (code * 17) + obj.Variety.GetHashCode();
            }
            return code;
        }
    }
