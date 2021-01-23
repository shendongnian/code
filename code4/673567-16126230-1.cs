    public struct vector
    {
        private readonly int x;
        private readonly int y;
        public vector(int theX, int theY)
        {
            x = theX;
            y = theY;
        }
        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }
        public vector SetX(int x) 
        {
            return new vector(x, this.y);
        }
        public vector SetY(int y) 
        {
            return new vector(this.x, y);
        }
        .. other operations
    }
    me.myVector = me.myVector.SetX(200);
