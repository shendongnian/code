    class Program
    {
        ArrayList array = null;
        public Program(int size)
        {
            array = new ArrayList(size);
        }
        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Count)
                {
                    return (null);
                }
                else
                {
                    return (array[index]);
                }
            }
            set
            {
                array[index] = value;
            }
        }
        public int Count
        {
            get
            {
                return array.Count;
            }
        }
    }
