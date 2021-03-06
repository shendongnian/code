    // I could be wrong in that this is called natural order.
    class NaturalOrderByteArrayComparer : IComparer<byte[]>
    {
        public int Compare(byte[] x, byte[] y)
        {
            // Shortcuts: If both are null, they are the same.
            if (x == null && y == null) return 0;
    
            // If one is null and the other isn't, then the
            // one that is null is "lesser".
            if (x == null && y != null) return -1;
            if (x != null && y == null) return 1;
    
            // Both arrays are non-null.  Find the shorter
            // of the two lengths.
            int bytesToCompare = Math.Min(x.Length, y.Length);
    
            // Compare the bytes.
            for (int index = 0; index < bytesToCompare; ++index)
            {
                // The x and y bytes.
                byte xByte = x[index];
                byte yByte = y[index];
    
                // Compare result.
                int compareResult = Comparer<byte>.Default.Compare(xByte, yByte);
    
                // If not the same, then return the result of the
                // comparison of the bytes, as they were the same
                // up until now.
                if (compareResult != 0) return compareResult;
    
                // They are the same, continue.
            }
    
            // The first n bytes are the same.  Compare lengths.
            // If the lengths are the same, the arrays
            // are the same.
            if (x.Length == y.Length) return 0;
    
            // Compare lengths.
            return x.Length < y.Length ? -1 : 1;
        }
    }
