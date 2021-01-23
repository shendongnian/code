    interface INbtTag
    {
        object GetValue(); 
    }
    interface INbtTag<out T> : INbtTag
    {
        T GetValue();
    }
    class NbtByte : INbtTag<byte>
    {
        byte value;
        public byte GetValue() // implicit implementation of generic interface
        {
            return value;
        }
        object INbtTag.GetValue() // explicit implementation of non-generic interface
        {
            return this.GetValue(); // delegates to method above
        }
    }
