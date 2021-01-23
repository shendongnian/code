    using System;
    using System.Runtime.InteropServices;
    
    namespace DiskFreeSpaceEx
    {
        internal class FreeSpace
        {
            [DllImport("kernel32")]
            public static extern int GetDiskFreeSpaceEx(string lpDirectoryName,ref long    lpFreeBytesAvailable,ref long lpTotalNumberOfBytes,ref long lpTotalNumberOfFreeBytes);
            const string RootPathName = @"\\server\share";
            private static void Main(string[] args)
            {
                long freeBytesAvailable = 0;
                long totalNumberOfBytes = 0;
                long totalNumberOfFreeBytes = 0;
    
                GetDiskFreeSpaceEx(RootPathName, ref freeBytesAvailable, ref
                   totalNumberOfBytes, ref totalNumberOfFreeBytes);
    
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", RootPathName,
                    freeBytesAvailable, totalNumberOfBytes, totalNumberOfFreeBytes);
            }
        }
    }
