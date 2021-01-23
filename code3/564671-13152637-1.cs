        [StructLayout(LayoutKind.Sequential, Size = 64)]
        unsafe struct Row
        {
            public int this[int index]
            {
                get
                {
                    // need validation of index or AV
                    fixed (Row* p = &this)
                    {
                        int* value = (int*)p;
                        return *(value + index);
                    }
                }
                set
                {
                    // need validation of index or AV
                    fixed (Row* p = &this)
                    {
                        int* item = (int*)p;
                        item += index;
                        *item = value;
                    }
                }
            }
        }
