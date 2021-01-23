    class Program
    {        
        static void Main(string[] args)
        {
            // To the metal, baby!
            using (var fileHandle = NativeMethods.CreateFile(
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
                if (fileHandle.IsInvalid)
                {
                    // Doh!
                    throw new Win32Exception();
                }
                else
                {
                    // Boot sector ~ 512 bytes long
                    byte[] buffer = new byte[512];
                    NativeOverlapped overlapped = new NativeOverlapped();
                    NativeMethods.ReadFile(fileHandle, buffer, buffer.Length, IntPtr.Zero, ref overlapped);
                    // Pin it so we can transmogrify it into a FAT structure
                    var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    try
                    {
                        // note, I've got an NTFS drive, change yours to suit
                        var bootSector = (BootSector_NTFS)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(BootSector_NTFS));
                        Console.WriteLine(
                            "I think that the Master File Table is at absolute position:{0}, sector:{1}",
                            bootSector.GetMftAbsoluteIndex(),
                            bootSector.GetMftAbsoluteIndex() / bootSector.BytesPerSector);
                        Console.WriteLine("MFT record size:{0}", bootSector.ClustersPerMftRecord * bootSector.SectorsPerCluster * bootSector.BytesPerSector);
                        // If you've got LinqPad, uncomment this to look at boot sector
                        bootSector.DumpToHtmlString();
                        Pause();
                        Console.WriteLine("Jumping to Master File Table...");
                        long lpNewFilePointer;
                        if (!NativeMethods.SetFilePointerEx(fileHandle, bootSector.GetMftAbsoluteIndex(), out lpNewFilePointer, SeekOrigin.Begin))
                        {
                            throw new Win32Exception();
                        }
                        Console.WriteLine("Position now: {0}", lpNewFilePointer);
                        // Read in one MFT entry
                        byte[] mft_buffer = new byte[bootSector.GetMftEntrySize()];
                        Console.WriteLine("Reading $MFT entry...calculated size: 0x{0}", bootSector.GetMftEntrySize().ToString("X"));
                        var seekIndex = bootSector.GetMftAbsoluteIndex();
                        overlapped.OffsetHigh = (int)(seekIndex >> 32);
                        overlapped.OffsetLow = (int)seekIndex;
                        NativeMethods.ReadFile(fileHandle, mft_buffer, mft_buffer.Length, IntPtr.Zero, ref overlapped);
                        // Pin it for transmogrification
                        var mft_handle = GCHandle.Alloc(mft_buffer, GCHandleType.Pinned);
                        try
                        {
                            var mftRecords = (MFTSystemRecords)Marshal.PtrToStructure(mft_handle.AddrOfPinnedObject(), typeof(MFTSystemRecords));
                            mftRecords.DumpToHtmlString();
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
                }
            }
            Pause();
        }
        private static void Pause()
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
    public static class Dumper
    {
        public static string DumpToHtmlString<T>(this T objectToSerialize)
        {
            string strHTML = "";
            try
            {
                var writer = LINQPad.Util.CreateXhtmlWriter(true);
                writer.Write(objectToSerialize);
                strHTML = writer.ToString();
            }
            catch (Exception exc)
            {
                Debug.Assert(false, "Investigate why ?" + exc);
            }
            var shower = new Thread(
                () =>
                    {
                        var dumpWin = new Window();
                        var browser = new WebBrowser();
                        dumpWin.Content = browser;
                        browser.NavigateToString(strHTML);
                        dumpWin.ShowDialog();                        
                    });
            shower.SetApartmentState(ApartmentState.STA);
            shower.Start();
            return strHTML;
        }
        public static string Dump(this object value)
        {
             return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
