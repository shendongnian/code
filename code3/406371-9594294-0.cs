    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO.Packaging;
    using System.Runtime.InteropServices;
    using System.IO;
    namespace ExtractOLEPowerPoint
    {
    class Program
    {
        #region IEnumSTATSTG
        [ComImport]
        [Guid("0000000d-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IEnumSTATSTG
        {
            // The user needs to allocate an STATSTG array whose size is celt.
            [PreserveSig]
            uint Next(uint celt, [MarshalAs(UnmanagedType.LPArray), Out] System.Runtime.InteropServices.ComTypes.STATSTG[] rgelt, out uint pceltFetched);
            void Skip(uint celt);
            void Reset();
            [return: MarshalAs(UnmanagedType.Interface)]
            IEnumSTATSTG Clone();
        }
        #endregion
        //#region IStream
        //[ComImport, Guid("0000000c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        //public interface IStream
        //{
        //    void Read([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, uint cb, out uint pcbRead);
        //    void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, uint cb, out uint pcbWritten);
        //    void Seek(long dlibMove, uint dwOrigin, out long plibNewPosition);
        //    void SetSize(long libNewSize);
        //    void CopyTo(IStream pstm, long cb, out long pcbRead, out long pcbWritten);
        //    void Commit(uint grfCommitFlags);
        //    void Revert();
        //    void LockRegion(long libOffset, long cb, uint dwLockType);
        //    void UnlockRegion(long libOffset, long cb, uint dwLockType);
        //    void Stat(out STATSTG pstatstg, uint grfStatFlag);
        //    void Clone(out IStream ppstm);
        //}
        //#endregion
        #region STATFLAG
        [Flags]
        public enum STATFLAG : uint
        {
            STATFLAG_DEFAULT = 0,
            STATFLAG_NONAME = 1,
            STATFLAG_NOOPEN = 2
        }
        #endregion
        #region IStorage
        [ComImport]
        [Guid("0000000b-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IStorage
        {
            void CreateStream(
                /* [string][in] */ string pwcsName,
                /* [in] */ uint grfMode,
                /* [in] */ uint reserved1,
                /* [in] */ uint reserved2,
                /* [out] */ out System.Runtime.InteropServices.ComTypes.IStream ppstm);
            void OpenStream(
                /* [string][in] */ string pwcsName,
                /* [unique][in] */ IntPtr reserved1,
                /* [in] */ uint grfMode,
                /* [in] */ uint reserved2,
                /* [out] */ out System.Runtime.InteropServices.ComTypes.IStream ppstm);
            void CreateStorage(
                /* [string][in] */ string pwcsName,
                /* [in] */ uint grfMode,
                /* [in] */ uint reserved1,
                /* [in] */ uint reserved2,
                /* [out] */ out IStorage ppstg);
            void OpenStorage(
                /* [string][unique][in] */ string pwcsName,
                /* [unique][in] */ IStorage pstgPriority,
                /* [in] */ uint grfMode,
                /* [unique][in] */ IntPtr snbExclude,
                /* [in] */ uint reserved,
                /* [out] */ out IStorage ppstg);
            void CopyTo(
                /* [in] */ uint ciidExclude,
                /* [size_is][unique][in] */ Guid rgiidExclude, // should this be an array?
                /* [unique][in] */ IntPtr snbExclude,
                /* [unique][in] */ IStorage pstgDest);
            void MoveElementTo(
                /* [string][in] */ string pwcsName,
                /* [unique][in] */ IStorage pstgDest,
                /* [string][in] */ string pwcsNewName,
                /* [in] */ uint grfFlags);
            void Commit(
                /* [in] */ uint grfCommitFlags);
            void Revert();
            void EnumElements(
                /* [in] */ uint reserved1,
                /* [size_is][unique][in] */ IntPtr reserved2,
                /* [in] */ uint reserved3,
                /* [out] */ out IEnumSTATSTG ppenum);
            void DestroyElement(
                /* [string][in] */ string pwcsName);
            void RenameElement(
                /* [string][in] */ string pwcsOldName,
                /* [string][in] */ string pwcsNewName);
            void SetElementTimes(
                /* [string][unique][in] */ string pwcsName,
                /* [unique][in] */ System.Runtime.InteropServices.ComTypes.FILETIME pctime,
                /* [unique][in] */ System.Runtime.InteropServices.ComTypes.FILETIME patime,
                /* [unique][in] */ System.Runtime.InteropServices.ComTypes.FILETIME pmtime);
            void SetClass(
                /* [in] */ Guid clsid);
            void SetStateBits(
                /* [in] */ uint grfStateBits,
                /* [in] */ uint grfMask);
            void Stat(
                /* [out] */ out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg,
                /* [in] */ uint grfStatFlag);
        }
        #endregion
        #region STGM
        [Flags]
        public enum STGM : int
        {
            DIRECT           = 0x00000000,
            TRANSACTED       = 0x00010000,
            SIMPLE           = 0x08000000,
            READ             = 0x00000000,
            WRITE            = 0x00000001,
            READWRITE        = 0x00000002,
            SHARE_DENY_NONE  = 0x00000040,
            SHARE_DENY_READ  = 0x00000030,
            SHARE_DENY_WRITE = 0x00000020,
            SHARE_EXCLUSIVE  = 0x00000010,
            PRIORITY         = 0x00040000,
            DELETEONRELEASE  = 0x04000000,
            NOSCRATCH        = 0x00100000,
            CREATE           = 0x00001000,
            CONVERT          = 0x00020000,
            FAILIFTHERE      = 0x00000000,
            NOSNAPSHOT       = 0x00200000,
            DIRECT_SWMR      = 0x00400000,
        }
        #endregion
        #region StgIsStorageFile
        [DllImport("Ole32.dll")]
        static extern int StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)]string filename);
        #endregion
        #region StgOpenStorage
        [DllImport("Ole32.dll")]
        static extern int StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)]string pwcsName, IStorage pstgPriority, STGM grfmode, IntPtr snbExclude, uint researved, out IStorage ppstgOpen);
        #endregion
        static void Main(string[] args)
        {
            Package pkg = Package.Open("C:\\Temp\\Temp.pptx");
            foreach (PackagePart pkgprt in pkg.GetParts())
            {
                if(pkgprt.Uri.ToString().StartsWith("/ppt/embeddings/"))
                {
                    System.IO.Stream strm = pkgprt.GetStream();
                    byte[] buffer = new byte[strm.Length];
                    strm.Read(buffer, 0, (int)strm.Length);
                    strm.Close();
                    // Create a temporary file
                    string targetFile = "C:\\Temp\\GeneratedFiles\\" + pkgprt.Uri.ToString().Remove(0, "/ppt/embeddings/".Length);
                    System.IO.File.WriteAllBytes(targetFile, buffer);
                    // Extract the contents.
                    IStorage Is;
                    StgOpenStorage(targetFile, null, STGM.READWRITE | STGM.SHARE_EXCLUSIVE, IntPtr.Zero, 0, out Is);
                    ProcessPackage(Is);
                    // Need to release the IStorage object and call GC.Collect() to free the object
                    Marshal.ReleaseComObject(Is);
                    Is = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    // Delete the temporary binary file extracted
                    File.Delete(targetFile);
                }
            }
        }
        static void ProcessPackage(IStorage pStg)
        {
            System.Runtime.InteropServices.ComTypes.IStream pStream;
            IEnumSTATSTG pEnumStatStg;
            uint numReturned;
            pStg.EnumElements(0, IntPtr.Zero, 0, out pEnumStatStg);
            System.Runtime.InteropServices.ComTypes.STATSTG[] ss = new System.Runtime.InteropServices.ComTypes.STATSTG[1];
            // Loop through the STATSTG structures in the storage.
            do
            {
                // Retrieve the STATSTG structure
                pEnumStatStg.Next(1, ss, out numReturned);
                if (numReturned != 0)
                {
                    //System.Runtime.InteropServices.ComTypes.STATSTG statstm;
                    byte[] bytT = new byte[4];
                    // Check if the pwcsName contains "Ole10Native" stream which contain the actual embedded object
                    if (ss[0].pwcsName.Contains("Ole10Native") == true)
                    {
                        // Get the stream objectOpen the stream
                        pStg.OpenStream(ss[0].pwcsName, IntPtr.Zero, (uint)STGM.READ | (uint)STGM.SHARE_EXCLUSIVE, 0, out pStream);
                        //pStream.Stat(out statstm, (int) STATFLAG.STATFLAG_DEFAULT);
                        IntPtr position = IntPtr.Zero;
                        // File name starts from 7th Byte.
                        // Position the cursor to the 7th Byte.
                        pStream.Seek(6, 0, position);
                        IntPtr ulRead = new IntPtr();
                        char[] filename = new char[260];
                        int i;
                        // Read the File name of the embedded object
                        for (i = 0; i < 260; i++)
                        {
                            pStream.Read(bytT, 1, ulRead);
                            pStream.Seek(0, 1, position);
                            filename[i] = (char)bytT[0];
                            if (bytT[0] == 0)
                            {
                                break;
                            }
                        }
                        string path = new string(filename, 0, i);
                        // Next part is the source path of the embedded object.
                        // Length is unknown. Hence, loop through each byte to read the 0 terminated string
                        // Read the source path.
                        for (i = 0; i < 260; i++)
                        {
                            pStream.Read(bytT, 1, ulRead);
                            pStream.Seek(0, 1, position);
                            filename[i] = (char)bytT[0];
                            if (bytT[0] == 0)
                            {
                                break;
                            }
                        }
                        // Source File path
                        string fullpath = new string(filename, 0, i);
                        // Unknown 4 bytes
                        pStream.Seek(4, 1, position);
                        // Next 4 byte gives the length of the temporary file path 
                        // (Office uses a temporary location to copy the files before inserting to the document)
                        // The length is in little endian format. Hence conversion is needed
                        pStream.Read(bytT, 4, ulRead);
                        ulong dwSize, dwTemp;
                        dwSize = 0;
                        dwTemp = (ulong)bytT[3];
                        dwSize += (ulong)(bytT[3] << 24);
                        dwSize += (ulong)(bytT[2] << 16);
                        dwSize += (ulong)(bytT[1] << 8);
                        dwSize += bytT[0];
                        // Skip the temporary file path
                        pStream.Seek((long)dwSize, 1, position);
                        // Next four bytes gives the size of the actual data in little endian format.
                        // Convert the format.
                        pStream.Read(bytT, 4, ulRead);
                        dwTemp = 0;
                        dwSize = 0;
                        dwTemp = (ulong)bytT[3];
                        dwSize += (ulong)(bytT[3] << 24);
                        dwSize += (ulong)(bytT[2] << 16);
                        dwSize += (ulong)(bytT[1] << 8);
                        dwSize += (ulong)bytT[0];
                        
                        // Read the actual file content 
                        byte[] byData = new byte[dwSize];
                        pStream.Read(byData, (int)dwSize, ulRead);
                        // Create the file
                        System.IO.BinaryWriter bWriter = new System.IO.BinaryWriter(System.IO.File.Open("C:\\temp\\GeneratedFiles\\" + path, System.IO.FileMode.Create));
                        bWriter.Write(byData);
                        bWriter.Close();
                    }
                }
            }
            while (numReturned > 0);
        }
    }
    }
 
