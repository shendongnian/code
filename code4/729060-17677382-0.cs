    public static class Apply
    {
        public static To<T>(this Action<T> actionToCarryOut,params T[] listOfThings)
        {
            foreach (var thing in listOfThings)
            {
                actionToCarryOut(thing);
            }
        }
    }
