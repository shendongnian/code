      public static class Extensions
        {
            public static SqlParameter AddWithNullValue(this SqlParameterCollection collection, string parameterName, object value)
            {
                if (value == null)
                    return collection.AddWithValue(parameterName, DBNull.Value);
                else
                    return collection.AddWithValue(parameterName, value);
            }
        }
