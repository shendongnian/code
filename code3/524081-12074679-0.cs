        private static T Convert<T>(string input)
        {
            if (input == null) throw new ArgumentNullException("input");
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (input.Is(typeof(T)))
            {
                try
                {
                    return (T)converter.ConvertFromString(input);
                }
                catch (NotSupportedException notSupportedException)
                {
                    Console.WriteLine(notSupportedException);
                }
            }
            return default(T);
        }
