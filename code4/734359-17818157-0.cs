    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using Microsoft.Win32.SafeHandles;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    namespace NTFS.Sparse
    {
        public class SparseFile
        {
            private static int ERROR_MORE_DATA = 234;
    
            public static FileStream Create(string fileName)
            {
                if (!VolumeSupportsSparseFiles(fileName))
                {
                    throw new IOException("Specified volume does not support sparse files.");
                }
    
                // Native code sample from http://www.flexhex.com/docs/articles/sparse-files.phtml
                /*
                    HANDLE hFile = ::CreateFile("C:\\Sparse.dat", GENERIC_WRITE,
                                         0, NULL, CREATE_NEW, FILE_ATTRIBUTE_NORMAL, NULL);
                    DWORD dwTemp;
                    ::DeviceIoControl(hFile, FSCTL_SET_SPARSE, NULL, 0, NULL, 0, &dwTemp, NULL);
                */
    
                uint dwShareMode = (uint)Win32.EFileShare.None;
                uint dwDesiredAccess = (uint)Win32.EFileAccess.GenericWrite;
                uint dwFlagsAndAttributes = (uint)Win32.EFileAttributes.Normal;
                uint dwCreationDisposition = (uint)Win32.ECreationDisposition.CreateAlways;
    
                SafeFileHandle fileHandle =
                    Win32.Methods.CreateFileW(
                        fileName,
                        dwDesiredAccess,
                        dwShareMode,
                        IntPtr.Zero,
                        dwCreationDisposition,
                        dwFlagsAndAttributes,
                        IntPtr.Zero);
    
                int bytesReturned = 0;
                NativeOverlapped lpOverlapped = new NativeOverlapped();
                bool result =
                    Win32.Methods.DeviceIoControl(
                        fileHandle,
                        Win32.EIoControlCode.FsctlSetSparse,
                        IntPtr.Zero,
                        0,
                        IntPtr.Zero,
                        0,
                        ref bytesReturned,
                        ref lpOverlapped);
    
                return new System.IO.FileStream(fileHandle, System.IO.FileAccess.Write);
    
            }
            unsafe public static void SetSparseRange(SafeFileHandle fileHandle, uint startIx, uint zeroBlockLength)
            {
                // Native code sample from http://www.flexhex.com/docs/articles/sparse-files.phtml
                /*
                FILE_ZERO_DATA_INFORMATION fzdi;
                DWORD dwTemp;
    
                fzdi.FileOffset.QuadPart = uAddress;
                fzdi.BeyondFinalZero.QuadPart = uAddress + uSize;
                ::DeviceIoControl(hFile, FSCTL_SET_ZERO_DATA,
                                  &fzdi, sizeof(fzdi), NULL, 0, &dwTemp, NULL);
                */
                int dwTemp = 0;
                NativeOverlapped lpOverlapped = new NativeOverlapped();
    
                Win32.FILE_ZERO_DATA_INFORMATION fzd;
                fzd.FileOffset = startIx;
                fzd.BeyondFinalZero= startIx + zeroBlockLength;
    
                IntPtr ptrFZD = new IntPtr(&fzd);
    
                bool result =
                    Win32.Methods.DeviceIoControl(
                        fileHandle,
                        Win32.EIoControlCode.FsctlSetZeroData,
                        ptrFZD,
                        sizeof(Win32.FILE_ZERO_DATA_INFORMATION),
                        IntPtr.Zero,
                        0,
                        ref dwTemp,
                        ref lpOverlapped);
    
                //IntPtr ptrFZD = IntPtr.Zero;
                //try
                //{
                //    ptrFZD = Marshal.AllocHGlobal(Marshal.SizeOf(fzd));
                //    Marshal.StructureToPtr(fzd, ptrFZD, true);
    
                //    bool result = 
                //        Win32.Methods.DeviceIoControl(
                //            fileHandle, 
                //            Win32.EIoControlCode.FsctlSetZeroData, 
                //            ptrFZD, 
                //            Marshal.SizeOf(fzd), 
                //            IntPtr.Zero, 
                //            0, 
                //            ref dwTemp, 
                //            ref lpOverlapped);
                //}
                //finally
                //{
                //    Marshal.DestroyStructure(ptrFZD, typeof(Win32.FILE_ZERO_DATA_INFORMATION));
                //}
            }
            #region VolumeSupportsSparseFiles
            private static int FILE_SUPPORTS_SPARSE_FILES = 64;
            internal static bool VolumeSupportsSparseFiles(string filename)
            {
                string targetVolume = System.IO.Path.GetPathRoot(filename);
    
                // Native code sample from http://www.flexhex.com/docs/articles/sparse-files.phtml
                /*
                    char szVolName[MAX_PATH], szFSName[MAX_PATH];
                    DWORD dwSN, dwMaxLen, dwVolFlags;
                    ::GetVolumeInformation("C:\\", szVolName, MAX_PATH, &dwSN,
                                           &dwMaxLen, &dwVolFlags, szFSName, MAX_PATH);
    
                    if (dwVolFlags & FILE_SUPPORTS_SPARSE_FILES) {
                      // File system supports sparse streams
                    }
                    else {
                      // Sparse streams are not supported
                    }
                */
    
                uint nVolumeNameSize = 300; // TODO: How to determine the max possible length before querying?
                StringBuilder lpVolumeNameBuffer = new StringBuilder((int)nVolumeNameSize);
    
                uint nFileSystemNameSize = 300; // TODO: How to determine the max possible length before querying?
                StringBuilder lpFileSystemNameBuffer = new StringBuilder((int)nFileSystemNameSize);
    
                uint lpFileSystemFlags;
                uint lpVolumeSerialNumber;
                uint lpMaxComponentLength;
    
                bool result = Win32.Methods.GetVolumeInformationW(targetVolume, lpVolumeNameBuffer, nVolumeNameSize, out lpVolumeSerialNumber, out lpMaxComponentLength, out lpFileSystemFlags, lpFileSystemNameBuffer, nFileSystemNameSize);
    
                if (((uint)lpFileSystemFlags & FILE_SUPPORTS_SPARSE_FILES) == FILE_SUPPORTS_SPARSE_FILES)
                {
                    //if (System.Diagnostics.Debugger.IsAttached)
                    //{
                    //    Console.WriteLine("Volume supports sparse files.");
                    //    Console.WriteLine("Volume Name: " + lpVolumeNameBuffer.ToString());
                    //    Console.WriteLine("FileSystemName: " + lpFileSystemNameBuffer.ToString());
                    //    Console.WriteLine("lpVolumeSerialNumber: " + lpVolumeSerialNumber.ToString());
                    //    Console.WriteLine("lpMaxComponentLength: " + lpMaxComponentLength.ToString());
                    //    Console.WriteLine("lpFileSystemFlags: " + lpFileSystemFlags.ToString());
                    //}
                    return true;
                }
                else
                {
                    //if (System.Diagnostics.Debugger.IsAttached)
                    //{
                    //    try
                    //    {
                    //        Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        System.Diagnostics.Debugger.Break();
                    //    }
                    //}
                    return false;
                }
            }
            #endregion
    
            public class SparseRange
            {
                public SparseRange(long fileOffset, long length)
                {
                    this.FileOffset = FileOffset;
                    this.Length = length;
                }
                public long FileOffset { get; set; }
                public long Length { get; set; }
            }
            unsafe public static List<SparseRange> GetSparseRanges(FileInfo targetFile)
            {
                // Native code sample from http://www.flexhex.com/docs/articles/sparse-files.phtml
    
                if (!targetFile.Exists) throw new FileNotFoundException();
                if (!VolumeSupportsSparseFiles(targetFile.FullName)) throw new InvalidOperationException("The specified volume does not support sparse files.");
    
                var knownSparseRanges = new List<SparseRange>();
    
                using (FileStream fsTargetFile = targetFile.Open(FileMode.Open))
                {
                    // set file ranges to query the whole file
                    Win32.FILE_ALLOCATED_RANGE_BUFFER queryRange;
                    queryRange.FileOffset = 0;
                    queryRange.Length = targetFile.Length;
    
                    // DeviceIoControl will return as many results as fit into this buffer
                    // and will report error code ERROR_MORE_DATA as long as more data is available
                    Win32.FILE_ALLOCATED_RANGE_BUFFER[] reportedSparseRanges = new NTFS.Sparse.Win32.FILE_ALLOCATED_RANGE_BUFFER[1024];
    
                    bool successfullyCompleted;
                    do
                    {
                        IntPtr queryRangePointer = new IntPtr(&queryRange);
                        GCHandle gchRanges = GCHandle.Alloc(reportedSparseRanges, GCHandleType.Pinned);
                        try
                        {
                            IntPtr reportedSparseRangesArrayPointer = gchRanges.AddrOfPinnedObject();
                            int numberOfBytesReturned = 0;
                            NativeOverlapped lpOverlapped = new NativeOverlapped();
    
                            // assuming ERROR_MORE_DATA is the only error occuring!
                            successfullyCompleted = Win32.Methods.DeviceIoControl(
                                    fsTargetFile.SafeFileHandle,
                                    NTFS.Sparse.Win32.EIoControlCode.FsctlQueryAllocatedRanges,
                                    queryRangePointer,
                                    Marshal.SizeOf(queryRange),
                                    reportedSparseRangesArrayPointer,
                                    sizeof(Win32.FILE_ALLOCATED_RANGE_BUFFER)*1024,
                                    ref numberOfBytesReturned,
                                    ref lpOverlapped);
    
                            ThrowIfUnexpectedError(successfullyCompleted);
    
                            int numberOfReportedSparseRanges = numberOfBytesReturned / sizeof(Win32.FILE_ALLOCATED_RANGE_BUFFER);
                            SaveSparseRanges(knownSparseRanges, reportedSparseRanges, numberOfReportedSparseRanges);
    
                            // set up for next query
                            if (!successfullyCompleted && numberOfReportedSparseRanges > 0)
                            {
                                queryRange.FileOffset = reportedSparseRanges[numberOfReportedSparseRanges - 1].FileOffset + reportedSparseRanges[numberOfReportedSparseRanges - 1].Length;
                                queryRange.Length = targetFile.Length - queryRange.FileOffset;
                            }
                        }
                        finally
                        {
                            if (gchRanges.IsAllocated) gchRanges.Free();
                        }
                    } while (!successfullyCompleted);
    
                    return knownSparseRanges;
                }
            }
    
            unsafe private static void ThrowIfUnexpectedError(bool successfullyCompleted)
            {
                if (!successfullyCompleted)
                {
                    int hResult = Marshal.GetHRForLastWin32Error();
                    if (hResult != ERROR_MORE_DATA)
                    {
                        Marshal.ThrowExceptionForHR(hResult);
                    }
                }
            }
    
            private static void SaveSparseRanges(List<SparseRange> results, Win32.FILE_ALLOCATED_RANGE_BUFFER[] ranges, int numberOfSparseRanges)
            {
                // do not replace with 'foreach' since not all entries will have valid data on every call!
                for (int ixSparseRangeInfo = 0; ixSparseRangeInfo < numberOfSparseRanges; ixSparseRangeInfo++)
                {
                    results.Add(
                        new SparseRange(
                            ranges[ixSparseRangeInfo].FileOffset,
                            ranges[ixSparseRangeInfo].Length));
                }
            }
        }
    }
