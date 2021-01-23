    class Tile
    {
        public Tile[] Neighbors { get; set; }
        public Func<int, int, int>[] XTransitions { get; set; }
        public Func<int, int, int>[] YTransitions { get; set; }
        public void GetXPlus(int x, int y, out int newX, out int newY, out Tile newTile)
        {
            x++;
            if (x <= 64)
            {
                newX = x;
                newY = y;
                newTile = this;
            }
            else
            {
                newX = XTransitions[(int)TileBorder.Right](x, y);
                newY = YTransitions[(int)TileBorder.Right](x, y);
                newTile = Neighbors[(int)TileBorder.Right];
            }
        }
        // ...
    }
