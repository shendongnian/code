    class Direction
    {
        private static readonly Direction _Up = new Direction();
        private static readonly Direction _Down = new Direction();
        private static readonly Direction _Left = new Direction();
        private static readonly Direction _Right = new Direction();
        public static implicit operator Direction(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    return _Up;
                case Keys.Down:
                    return _Down;
                case Keys.Left:
                    return _Left;
                case Keys.Right:
                    return _Right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private Direction() {}
    }
