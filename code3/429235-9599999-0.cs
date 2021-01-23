     class MinList<T>
        {
            T[] items;
            int position;
            public MinList()
            {
                items = new T[3];
                position = 0;
            }
    
            public void Add(T item)
            {
                items[position] = item;
                position++;
            }
        }
