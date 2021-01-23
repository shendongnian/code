    public static class MaybeMonad
    {
        public static TOut With<TIn, TOut>(this TIn input, Func<TIn, TOut> evaluator)
            where TIn : class
            where TOut : class
        {
            if (input == null)
            {
                return null;
            }
            else
            {
                return evaluator(input);
            }
        }
    }
