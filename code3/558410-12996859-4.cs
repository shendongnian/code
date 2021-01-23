    Result.Sort(new PositionComparer());
    class PositionComparer : IComparer<Position>
    {
        public int Compare(Position p1, Position p2) 
        { 
            var byCode = p1.Code.CompareTo(p2.Code); 
            return byCode == 0 ? p1.Name.CompareTo(p2.Name) : byCode; 
        }
    }
