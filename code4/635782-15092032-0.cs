    abstract class Direction
    {
        public static implicit operator Direction(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    return new Up();
                case Keys.Down:
                    return new Down();
                case Keys.Left:
                    return new Left();
                case Keys.Right:
                    return new Right();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    class Up : Direction {}
    class Down : Direction {}
    class Left : Direction {}
    class Right : Direction {}
    static class Program
    {
        static void Main()
        {
            Keys key = Keys.Up;
            Direction direction = key; // Legal
        }
    }
