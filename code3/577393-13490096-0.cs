    unsafe struct BytePtr
    {
        public BytePtr(byte *value)
        {
            _value = value;
        }
        private byte* _value;
        public byte* Value
        {
            get { return _value; }
        }
    }
