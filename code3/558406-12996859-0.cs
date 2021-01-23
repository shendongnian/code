    Result.Sort(new PositionComparer());
    class PositionComparer : IComparer<Position>
    {
        public int Compare(Position x, Position y)
        {
            var byCode = x.Code.CompareTo(y.Code);
            return byCode == 0 ? x.Name.CompareTo(y.Name) : byCode;
        }
    }
