    public static class DapperExtensions {
        public static IEnumerable<T> Query<T>(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) {
            var dapperResult = SqlMapper.Query<T>(cnn, sql, param, transaction, buffered, commandTimeout, commandType);
            var result = TrimStrings(dapperResult.ToList());
            return result;
        }
        static IEnumerable<T> TrimStrings<T>(IList<T> objects) {
            //todo: create an Attribute that can designate that a property shouldn't be trimmed if we need it
            var publicInstanceStringProperties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.PropertyType == typeof (string) && x.CanRead &&  x.CanWrite);
            foreach (var prop in publicInstanceStringProperties) {
                foreach (var obj in objects) {
                    var value = (string) prop.GetValue(obj);
                    var trimmedValue = value.SafeTrim();
                    prop.SetValue(obj, trimmedValue);
                }
            }
            return objects;
        }
        static string SafeTrim(this string source) {
            if (source == null) {
                return null;
            }
            return source.Trim();
        }
    }
