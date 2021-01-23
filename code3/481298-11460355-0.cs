        // On the actual StataDataReader
        public sbyte GetSByte(int i) {}
        // This is the smallest int available on IDataReader
        // It will call GetSByte internally if that is the column type
        public short GetInt16(int i){}
