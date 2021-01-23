    struct Point 
    { 
        public sbyte X { get; private set; }
        public sbyte Y { get; private set; }
        public Point(sbyte x, sbyte y)
        {
            this.X = x;
            this.Y = y;
        }
        public override int GetHashCode()
        {
            return this.X << 8 | this.Y;
        }
        ...
    }
   
    Dictionary<Point, Cell> CellList
    Cell thisCell = CellList[new Point(thisX, thisY)];
