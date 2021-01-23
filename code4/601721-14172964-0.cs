    namespace System.Data {
        public static class MyExtensions {
            public static IEnumerable<DataRow> GetEnumerator( this DataTable table ) {
                foreach ( DataRow r in table.Rows ) yield return r;
            }
        }
    }
    foreach(DataRow row in table.GetEnumerator())
      .....
