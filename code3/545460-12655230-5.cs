    public class Matrix : List<List<int>>
    {
        public void RemoveRow(int i)
        {
            RemoveAt(i);
        }
        public void RemoveColumn(int i)
        {
            foreach (List<int> row in this) {
                row.RemoveAt(i);
            }
        }
        public void Remove(int i, int j)
        {
            RemoveRow(i);
            RemoveColumn(j);
        }
        // You can add other things like an indexer with two indexes
        public int this[int i, int j]
        {
            get { return this[i][j]; }
            set { this[i][j] = value; }
        }
    }
