    // setting the layout to sequential will prevent the compiler/JIT
    // to reorder the struct fields
    // NOTE: Observe here that the Charset used is Ansi. You may need to
    // change this depending on the format expected by the receiver.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct DataPacket
    {
    
        [MarshalAs(UnmanagedType.U4)]
        public uint Id;
    
        // As I understood from your question, the Name field
        // has a prefixed size of 40 bytes. Attention here:
        // the SizeConst actually means '40 characters', not bytes
        // If you choose to use the Unicode charset, set SizeConst = 20
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public String Name;
        // This will be serialized in little endian format
        // in your question this field is 8 bytes long, which 
        // in c# corresponds to the double type. If you really mean
        // the float type (4 bytes), change here.
        public double Grade;
    
        // Calling this method will return a byte array with the contents
        // of the struct ready to be sent via the tcp socket.
        public byte[] Serialize()
        {
            // allocate a byte array for the struct data
            var buffer = new byte[Marshal.SizeOf(typeof(DataPacket))];
                
            // Allocate a GCHandle and get the array pointer
            var gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var pBuffer = gch.AddrOfPinnedObject();
    
            // copy data from struct to array and unpin the gc pointer
            Marshal.StructureToPtr(this, pBuffer, false);
            gch.Free();
    
            return buffer;
        }
    
        // this method will deserialize a byte array into the struct.
        public void Deserialize(ref byte[] data)
        {
            var gch = GCHandle.Alloc(data, GCHandleType.Pinned);
            this = (DataPacket)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(DataPacket));
            gch.Free();
        }
    }
