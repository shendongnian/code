    public static class MyEnumerable
    {
        public static IEnumerable<TResult> Repeat<TResult>(Func<TResult> func)
        {
            for(;;)
            {
                yield return func();
            }	
        }
    }
