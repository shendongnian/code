        class Program
        {
            ArrayList array = new ArrayList();
            public int Count { get { return array.Count; } }
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
        }
