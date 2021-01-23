    public static class MathExtensions
    {
        public static int Round(this int i, int nearest)
        {
            if (nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a multiple of 10");
            return (i + 5 * nearest / 10) / nearest * nearest;
        }
    }
