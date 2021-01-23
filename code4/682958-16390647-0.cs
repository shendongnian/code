    public static class SelectSingleSpace
    {
        public static void DoStuff(this ISelectSingleSpace selectSingleSpace)
        {
            IEnumerable<Space> AvailableSpaces = selectSingleSpace.AvailableSpaces;
            Console.Write(AvailableSpaces.Count());
        }
    }
