    public abstract class Direction
    {
        public static implicit operator Direction(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    return Up.Instance;
                case Keys.Down:
                    return Down.Instance;
                case Keys.Left:
                    return Left.Instance;
                case Keys.Right:
                    return Right.Instance;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class Up : Direction
    {
        private static readonly Up _Instance = new Up();
        public static Up Instance
        {
            get { return _Instance; }
        }
        private Up() {}
    }
    public class Down : Direction
    {
        private static readonly Down _Instance = new Down();
        public static Down Instance
        {
            get { return _Instance; }
        }
        private Down() {}
    }
    public class Left : Direction
    {
        private static readonly Left _Instance = new Left();
        public static Left Instance
        {
            get { return _Instance; }
        }
        private Left() {}
    }
    public class Right : Direction
    {
        private static readonly Right _Instance = new Right();
        public static Right Instance
        {
            get { return _Instance; }
        }
        private Right() {}
    }
