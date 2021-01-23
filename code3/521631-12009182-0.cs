    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ArrayStructFieldAttribute : Attribute
    {
        public ArrayStructFieldAttribute(int index)
        {
            this.index = index;
        }
        private readonly int index;
        public int Index {
            get {
                return index;
            }
        }
    }
