    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion 
    
    namespace MyHelpers
    {
        public static class StringJoinExtensions
        {
            public static string JoinAnd<T>(this IEnumerable<T> values, 
                 string separator, string lastSeparator = null)
            {
                if (values == null)
                    throw new ArgumentNullException(nameof(values));
                if (separator == null)
                    throw new ArgumentNullException(nameof(separator));
    
                var sb = new StringBuilder();
                var enumerator = values.GetEnumerator();
    
                if (enumerator.MoveNext())
                    sb.Append(enumerator.Current);
    
                bool objectIsSet = false;
                object obj = null;
                if (enumerator.MoveNext())
                {
                    obj = enumerator.Current;
                    objectIsSet = true;
                }
    
                while (enumerator.MoveNext())
                {
                    sb.Append(separator);
                    sb.Append(obj);
                    obj = enumerator.Current;
                    objectIsSet = true;
                }
    
                if (objectIsSet)
                {
                    sb.Append(lastSeparator ?? separator);
                    sb.Append(obj);
                }
    
                return sb.ToString();
            }
        }
    }
    
