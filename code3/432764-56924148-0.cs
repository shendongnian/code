    static public class Extensions {
        // extension for arrays, lists, any Enumerable -> AsString
        public static string AsString<T>(this IEnumerable<T> enumerable) {
            var sb = new StringBuilder();
            int inx = 0;
            foreach (var item in enumerable) {
                sb.Append($"{inx}: {item}\r\n");
                inx++;
            }
            return sb.ToString();
        }
    }
