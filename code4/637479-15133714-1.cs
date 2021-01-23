    public static class ListExtensions
    {
        public static void Move<T>(this IList<T> list, int iIndexToMove, 
            MoveDirection direction)
        {
            if (direction == MoveDirection.Up)
            {
                var old = list[iIndexToMove - 1];
                list[iIndexToMove - 1] = list[iIndexToMove];
                list[iIndexToMove] = old;
            }
            else
            {
                var old = list[iIndexToMove + 1];
                list[iIndexToMove + 1] = list[iIndexToMove];
                list[iIndexToMove] = old;
            }
        }
    }
    public enum MoveDirection
    {
        Up,
        Down
    }
