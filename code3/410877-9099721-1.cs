        public static T? ParseOrNull<T>(this string str)
            where T: struct, IConvertible
        {
            var parseMethod = typeof(T).GetMethod("TryParse", 
                                            BindingFlags.Public | BindingFlags.Static,
                                            Type.DefaultBinder,
                                            new[] { typeof(string), typeof(T).MakeByRefType() },
                                            null);
            var args = new object[] { str, default(T) };
            if ( (bool)parseMethod.Invoke(null, args))
                return (T?)args[1];
            return null;
        }
    }
