        public static double[] ToDoubleArray(this byte[] bytes)
        {
            Debug.Assert(bytes.Length % sizeof(double) == 0, "byte array must be aligned on the size of a double.");
            double[] doubles = new double[bytes.Length / sizeof(double)];
            GCHandle pinnedDoubles = GCHandle.Alloc(doubles, GCHandleType.Pinned);
            Marshal.Copy(bytes, 0, pinnedDoubles.AddrOfPinnedObject(), bytes.Length);
            pinnedDoubles.Free();
            return doubles;
        }
        public static double[] ToDoubleArray(this MemoryStream stream)
        {
            return stream.ToArray().ToDoubleArray();
        }
