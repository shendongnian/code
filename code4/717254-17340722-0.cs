        public static IObservable<Maybe<Exception>> Catch<T>
            ( this IObservable<T> source
            , Action<T> action
            )
        {
            return source.Select(p => {
                try
                {
                    action(p);
                    return None<Exception>.Default; 
                }
                catch (Exception e)
                {
                    return e.ToMaybe();
                }
            });
            
        }
