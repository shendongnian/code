        class RowProxy<T>: IList<T>
        {
            public RowProxy(T[,] source, int row)
            { 
               _source = source;
               _row = row;
            }
            public T this[int col]
            {
                get { return _source[_row, col]; } 
                set { _source[_row, col] = value; }
            }
            private T[,] _source;
            private int _row;
            // Implement the rest of the IList interface
        }
