    Did read 258.888.890 bytes with 77 MB/s
    
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.InteropServices;
    
    unsafe class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }
    
        private void Start()
        {
            var sw = Stopwatch.StartNew();
            string fileName = @"C:\Source\BigFile.txt";//@"C:\Source\Numbers.txt";
            var file = MemoryMappedFile.CreateFromFile(fileName);
            var fileSize = new FileInfo(fileName).Length;
            int viewSize = 200 * 100 * 1000;
            long offset = 0;
            for (; offset < fileSize-viewSize; offset +=viewSize ) // create 200 MB views
            {
                using (var accessor = file.CreateViewAccessor(offset, viewSize))
                {
                    int unReadBytes = ReadData(accessor, offset);
                    offset -= unReadBytes;
                }
            }
    
            using (var rest = file.CreateViewAccessor(offset, fileSize - offset))
            {
                ReadData(rest, offset);
            }
            sw.Stop();
            Console.WriteLine("Did read {0:N0} bytes with {1:F0} MB/s", fileSize, (fileSize / (1024 * 1024)) / sw.Elapsed.TotalSeconds);
        }
    
    
        List<int> Data = new List<int>();
    
        private int ReadData(MemoryMappedViewAccessor accessor, long offset)
        {
            using(var safeViewHandle = accessor.SafeMemoryMappedViewHandle)
            {
                byte* pStart = null;
                safeViewHandle.AcquirePointer(ref pStart);
                ulong correction = 0;
                // needed to correct offset because the view handle does not start at the offset specified in the CreateAccessor call
                // This makes AquirePointer nearly useless.
                // http://connect.microsoft.com/VisualStudio/feedback/details/537635/no-way-to-determine-internal-offset-used-by-memorymappedviewaccessor-makes-safememorymappedviewhandle-property-unusable
                pStart = Helper.Pointer(pStart, offset, out correction);
                var len = safeViewHandle.ByteLength - correction;
                bool digitFound = false;
                int curInt = 0;
                byte current =0;
                for (ulong i = 0; i < len; i++)
                {
                    current = *(pStart + i);
                    if (current == (byte)' ' && digitFound)
                    {
                        Data.Add(curInt);
                      //  Console.WriteLine("Add {0}", curInt);
                        digitFound = false;
                        curInt = 0;
                    }
                    else
                    {
                        curInt = curInt * 10 + (current - '0');
                        digitFound = true;
                    }
                }
    
                // scan backwards to find partial read number
                int unread = 0;
                if (curInt != 0 && digitFound)
                {
                    byte* pEnd = pStart + len;
                    while (true)
                    {
                        pEnd--;
                        if (*pEnd == (byte)' ' || pEnd == pStart)
                        {
                            break;
                        }
                        unread++;
    
                    }
                }
    
                safeViewHandle.ReleasePointer();
                return unread;
            }
        }
    
        public unsafe static class Helper
        {
            static SYSTEM_INFO info;
    
            static Helper()
            {
                GetSystemInfo(ref info);
            }
    
            public static byte* Pointer(byte *pByte, long offset, out ulong diff)
            {
                var num = offset % info.dwAllocationGranularity;
                diff = (ulong)num; // return difference
    
                byte* tmp_ptr = pByte;
    
                tmp_ptr += num;
    
                return tmp_ptr;
            }
    
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);
    
            internal struct SYSTEM_INFO
            {
                internal int dwOemId;
                internal int dwPageSize;
                internal IntPtr lpMinimumApplicationAddress;
                internal IntPtr lpMaximumApplicationAddress;
                internal IntPtr dwActiveProcessorMask;
                internal int dwNumberOfProcessors;
                internal int dwProcessorType;
                internal int dwAllocationGranularity;
                internal short wProcessorLevel;
                internal short wProcessorRevision;
            }
        }
    
        void GenerateNumbers()
        {
            using (var file = File.CreateText(@"C:\Source\BigFile.txt"))
            {
                for (int i = 0; i < 30 * 1000 * 1000; i++)
                {
                    file.Write(i.ToString() + " ");
                }
            }
        }
    
    }
