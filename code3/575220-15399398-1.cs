    // To the metal, baby!
    using(var fileHandle = CreateFile(
        // Magic "give me the device" syntax
        @"\\.\c:", 
        // MUST explicitly provide both of these, not ReadWrite
        FileAccess.Read | FileAccess.Write, 
        // MUST explicitly provide both of these, not ReadWrite
        FileShare.Write | FileShare.Read, 
        IntPtr.Zero, 
        FileMode.Open, 
        FileAttributes.Normal,
        IntPtr.Zero))
    {
        if(fileHandle.IsInvalid)
        {
            // Doh!
            throw new Win32Exception();
        }
        else
        {
            // Well, we all must start somewhere, 
            // and for us, the "somewhere" is the master boot record.
            // Boot sector ~ 512 bytes long
            byte[] buffer = new byte[512];
            NativeOverlapped overlapped = new NativeOverlapped();
            ReadFile(fileHandle, buffer, buffer.Length, IntPtr.Zero, ref overlapped);
            // Pin it so we can transmogrify it into a FAT structure
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {            
                // note, I've got an NTFS drive, change yours to suit
                var bootSector = (BootSector_NTFS)Marshal.PtrToStructure(
                     handle.AddrOfPinnedObject(), 
                     typeof(BootSector_NTFS));
