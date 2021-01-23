                // If you've got LinqPad, uncomment this to look at boot sector
                bootSector.Dump();
                Console.WriteLine("Jumping to Master File Table...");
                long lpNewFilePointer;
                SetFilePointerEx(fileHandle, bootSector.GetMftAbsoluteIndex(), out lpNewFilePointer, SeekOrigin.Begin);
                Console.WriteLine("Position now: {0}", lpNewFilePointer);
                // Read in one MFT entry
                byte[] mft_buffer = new byte[bootSector.GetMftEntrySize()];
                NativeOverlapped mft_overlapped = new NativeOverlapped();
                Console.WriteLine("Reading $MFT entry...");
                ReadFile(fileHandle, mft_buffer, mft_buffer.Length, IntPtr.Zero, ref mft_overlapped);
