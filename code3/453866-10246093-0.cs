    class Test
    {
        public byte [] byteArr_1 = new byte [1024];
        private GCHandle pinned;
        //public byte* P_byte;
    
        public unsafe void SetAddress(ref byte* p_b)
        {
            pinned = GCHandle.Alloc(byteArr_1, GCHandleType.Pinned);
            p_b = (byte*)pinned.AddrOfPinnedObject();
            // NOTE: Don't forget to free the GCHandle at some point via GCHandle.Free!
            // Remember that once this handle is freed, the pointer should not be used in any way.
        }
    }
