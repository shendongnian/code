        public class ColumnDataBuilder<T> : ColumnDataBuilder
        {
            public ColumnData<T> Create(string name, int width, ColumnType type, Func<T, string> dataFormater)
            {
                return new ColumnData<T>(name, width, type, dataFormater);
            }
        }
        public class ColumnDataBuilder
        {
            public static ColumnDataBuilder<T> ColumnsFor<T>(IEnumerable<T> data)
            {
                return new ColumnDataBuilder<T>();
            }
        }
