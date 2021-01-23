    public static class LinqExtensions
    {
        public static IMandatory<TOutput> Match<TInput, TOutput>(
            this IEnumerable<TInput> maybe,
            Func<TInput, TOutput> some, Func<TOutput> nothing)
        {
            if (maybe.Any())
            {
                return new Just<TOutput>(
                            some(
                                maybe.First()
                            )
                        );
            }
            else
            {
                return new Just<TOutput>(
                            nothing()
                        );
            }
        }
        public static T Fold<T>(this IMandatory<T> maybe)
        {
            return maybe.First();
        }
    }
