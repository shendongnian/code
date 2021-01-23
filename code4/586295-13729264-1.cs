        public struct TSItem<T>
        {
            public string Variable { get; private set; }
            public DateTime Date { get; private set; }
            public T Value { get; private set; }
        }
        public IEnumerator<IEnumerable<TSItem<T>>> GetEnumerator()
        {
            int rows = DataMatrix.GetLength(0);
            int cols = DataMatrix.GetLength(1);
            for (int c = 0; c < cols; c++)
            {
                var col = new List<TSItem<T>>();
                for (int r = 0; r < rows; c++)
                {
                    col.Add(new TSItem<T>(this.Variables[c], this.DateTime[r], 
                                    DataMatrix[r, c]));
                }
                yield return col;
            }
        }
