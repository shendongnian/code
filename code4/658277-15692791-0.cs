        public static IQueryable<T> LikeOr<T>(this IQueryable<T> source, string columnName, string searchTerm)
        {
            IEnumerable<string> words =
                searchTerm.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 1);
            var sb = new StringBuilder();
            for (int i = 0; i < words.Count(); i++)
            {
                if (i != 0)
                    sb.Append(" || ");
                sb.Append(string.Format("{0}.Contains(@{1})", columnName, i));
            }
            return source.Where(sb.ToString(), words.ToArray());
        }
