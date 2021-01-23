    public static IEnumerable<Datum> Addition(this IEnumerable<Datum> @this, double val) {
         return from datum in @this
                select new Datum {
                     DateTime = datum.DateTime,
                     Value = datum.Value + val
                };
     }
