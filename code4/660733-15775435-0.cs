        public static class Extensions
        {
            public static TResult Try<TObject, TResult>(this TObject source, Func<TObject, TResult> method, string message = null)
            {
                try
                {
                    return method(source);
                }
                catch (Exception e)
                {
                    //Some Logging or whatever, optionally using the message parameter;
                    return default(TResult);
                }
            }
        }
