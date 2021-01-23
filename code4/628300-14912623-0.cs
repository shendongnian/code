        internal class DataKeys : IComparable<DataKeys>
        {
            private int key;
            private string values;
            public DataKeys(int key, string values)
            {
                this.key = key;
                this.values = values;
            }
            internal int Key
            {
                get { return key; }
            }
            internal string Values
            {
                get { return Values; }
            }
            public int CompareTo(DataKeys other)
            {
                if (this.key > other.key) return 1;
                else if (this.key < other.key) return -1;
                else return 0;
            }
       
        }
