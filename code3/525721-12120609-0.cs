         public static class LINQException {
        public static void TryExample() {
            var LsWithEx = from p in Enumerable.Range(0, 10) select int.Parse("dsfksdj");
            var LsSkipEx = (from p in Enumerable.Range(0, 10) select int.Parse("dsfksdj")).SkipExceptions();
        }
        public static IEnumerable<T> SkipExceptions<T>(this IEnumerable<T> values)
        {
            using (var enumerator = values.GetEnumerator())
            {
                bool next = true;
                while (next)
                {
                    try
                    { next = enumerator.MoveNext();}
                    catch
                    { continue;}
                    if (next) yield return enumerator.Current;
                }
            }
        }
    }
        var obj = (from VAR in db.infos
                   where VAR.location.Trim() == "Lim"
                   select new
                   {
                       title = VAR.title.Trim(),
                   }).SkipExce.SingleOrDefault();
