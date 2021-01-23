                // If you've got LinqPad, uncomment this to look at boot sector
                bootSector.Dump();
        Console.WriteLine("Jumping to Master File Table...");
        long lpNewFilePointer;
        if (!NativeMethods.SetFilePointerEx(
                fileHandle, 
                bootSector.GetMftAbsoluteIndex(), 
                out lpNewFilePointer, 
                SeekOrigin.Begin))
        {
            throw new Win32Exception();
        }
        Console.WriteLine("Position now: {0}", lpNewFilePointer);
    
        // Read in one MFT entry
        byte[] mft_buffer = new byte[bootSector.GetMftEntrySize()];
        Console.WriteLine("Reading $MFT entry...calculated size: 0x{0}",
           bootSector.GetMftEntrySize().ToString("X"));
    
        var seekIndex = bootSector.GetMftAbsoluteIndex();
        overlapped.OffsetHigh = (int)(seekIndex >> 32);
        overlapped.OffsetLow = (int)seekIndex;
        NativeMethods.ReadFile(
              fileHandle, 
              mft_buffer, 
              mft_buffer.Length, 
              IntPtr.Zero, 
              ref overlapped);
        // Pin it for transmogrification
        var mft_handle = GCHandle.Alloc(mft_buffer, GCHandleType.Pinned);
        try
        {
            var mftRecords = (MFTSystemRecords)Marshal.PtrToStructure(
                  mft_handle.AddrOfPinnedObject(), 
                  typeof(MFTSystemRecords));
            mftRecords.Dump();
        }
        finally
        {
            // make sure we clean up
            mft_handle.Free();
        }
    }
    finally
    {
        // make sure we clean up
        handle.Free();
    }
