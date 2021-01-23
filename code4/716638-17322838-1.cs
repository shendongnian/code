    public class DataWrapper
    {
        private readonly object[][] data;
    
        public DataWrapper(object[] data)
        {
            this.data = data.Select(o => (object[])o ).ToArray();
        }
        public object this[int row, int col]
        {
            get { return this.data[row][col]; }
        }
    }
