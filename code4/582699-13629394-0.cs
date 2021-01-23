        public class ColumnDataBuilder
        {
            public static ColumnDataBuilder<T> ColumnsFor<T>(IEnumerable<T> data)
            {
                return new ColumnDataBuilder<T>(data);
            }
        }
        public class ColumnDataBuilder<T> : ColumnDataBuilder
        {
            public IEnumerable<T> Data { get; private set; }
            public ColumnDataBuilder(IEnumerable<T> data)
            {
                this.Data = data;
            }
            public ColumnData<T> Create(string name, int width, ColumnType type, Func<T, string> dataFormater)
            {
                return new ColumnData<T>(name, width, type, dataFormater);
            }
            public void populateFromData(params ColumnData<T>[] columns)
            {
                ///...
            }
        }
        public class ColumnData<T>
        {
            public ColumnData(string name, int width, ColumnType type, Func<T, string> dataFormatter)
            {
            }
        }
