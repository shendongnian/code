    public static void CallHelper<T>(int type, T[] data) {
        var hdl = GCHandle.Alloc(data, GCHandleType.Pinned);
        try {
            var vlen = new nc_vlen();
            vlen.len = data.Length;
            vlen.data = hdl.AddrOfPinnedObject();
            cmethod(ref type, ref vlen);
        }
        finally {
            hdl.Free();
        }
    }
