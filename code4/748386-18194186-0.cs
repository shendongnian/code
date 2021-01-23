    class Collection
    {
        int size;
        int items;
        string[] keys;
        object[] values;
        public Collection(int size)
        {
            keys = new string[size];
            values = new object[size];
            this.size = size;
            items = 0;
        }
        public object this[string index]
        {
            get
            {
                int position = -1;
                for (int i = 0; i < size ; i++)
                    if (keys[i] == index)
                        position = i;
                if (position == -1)
                    throw new ArgumentException("Index Not Found");
                return values[position];                
            }
            set
            {
                int position = -1;
                for (int i = 0; i < size; i++)
                    if (keys[i] != null && keys[i] == index)
                        position = i;
                if (position != -1)
                {
                    values[position] = value;
                }
                else
                {
                    if (items == size)
                        throw new Exception("Collection full");
                    keys[items] = index;
                    values[items] = value;
                    items++;
                }
            }
        }
    }
