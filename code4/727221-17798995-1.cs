    public sealed class CabFile : IDisposable
    {
        private IntPtr _hfdi;
        private ERF _erf;
        private GCHandle _erfHandle;
        private byte[] _data;
        private Dictionary<IntPtr, object> _handles = new Dictionary<IntPtr, object>();
        private MemoryStream _currentEntryData;
        private FNALLOC _alloc;
        private FNCLOSE _close;
        private FNFREE _free;
        private FNOPEN _open;
        private FNREAD _read;
        private FNWRITE _write;
        private FNSEEK _seek;
        private FNFDINOTIFY _extract;
        public event EventHandler<CabEntryExtractEventArgs> EntryExtract;
        public CabFile(string filePath)
            : this(GetStream(filePath))
        {
        }
        private static Stream GetStream(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        public CabFile(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            using (MemoryStream data = new MemoryStream())
            {
                stream.CopyTo(data);
                _data = data.ToArray();
            }
            _erf = new ERF();
            _alloc = new FNALLOC(FnAlloc);
            _free = new FNFREE(FnFree);
            _close = new FNCLOSE(FnClose);
            _open = new FNOPEN(FnOpen);
            _read = new FNREAD(FnRead);
            _write = new FNWRITE(FnWrite);
            _seek = new FNSEEK(FnSeek);
            _extract = new FNFDINOTIFY(FnNotifyExtract);
            _erfHandle = GCHandle.Alloc(_erf, GCHandleType.Pinned);
            _hfdi = FDICreate(
                Marshal.GetFunctionPointerForDelegate(_alloc),
                Marshal.GetFunctionPointerForDelegate(_free),
                Marshal.GetFunctionPointerForDelegate(_open),
                Marshal.GetFunctionPointerForDelegate(_read),
                Marshal.GetFunctionPointerForDelegate(_write),
                Marshal.GetFunctionPointerForDelegate(_close),
                Marshal.GetFunctionPointerForDelegate(_seek)
                , -1, _erfHandle.AddrOfPinnedObject());
        }
        public void ExtractEntries()
        {
            FDICopy(_hfdi, string.Empty, string.Empty, 0, Marshal.GetFunctionPointerForDelegate(_extract), IntPtr.Zero, IntPtr.Zero);
        }
        public void Dispose()
        {
            if (_hfdi != IntPtr.Zero)
            {
                FDIDestroy(_hfdi);
                _hfdi = IntPtr.Zero;
            }
            _erfHandle.Free();
        }
        private void OnEntryExtract(CabEntry entry)
        {
            EventHandler<CabEntryExtractEventArgs> handler = EntryExtract;
            if (handler != null)
            {
                handler(this, new CabEntryExtractEventArgs(entry));
            }
        }
        private IntPtr FnAlloc(int cb)
        {
            return Marshal.AllocHGlobal(cb);
        }
        private void FnFree(IntPtr pv)
        {
            Marshal.FreeHGlobal(pv);
        }
        private IntPtr FnOpen(string pszFile, int oflag, int pmode)
        {
            // only used for reading archive
            IntPtr h = new IntPtr(_handles.Count + 1);
            _handles.Add(h, 0);
            return h;
        }
        private int FnRead(IntPtr hf, byte[] pv, int cb)
        {
            // only used for reading archive
            int pos = (int)_handles[hf];
            int left = _data.Length - pos;
            int read = Math.Min(left, cb);
            if (read > 0)
            {
                Array.Copy(_data, pos, pv, 0, read);
                _handles[hf] = pos + read;
            }
            return read;
        }
        private int FnWrite(IntPtr hf, byte[] pv, int cb)
        {
            // only used for writing entries
            _currentEntryData.Write(pv, 0, cb);
            return cb;
        }
        private int FnClose(IntPtr hf)
        {
            object o = _handles[hf];
            CabEntry entry = o as CabEntry;
            if (entry != null)
            {
                entry.Data = _currentEntryData.ToArray();
                _currentEntryData.Dispose();
            }
            _handles.Remove(hf);
            return 0;
        }
        private int FnSeek(IntPtr hf, int dist, SeekOrigin seektype)
        {
            // only used for seeking archive
            int pos;
            switch (seektype)
            {
                case SeekOrigin.Begin:
                    pos = dist;
                    break;
                case SeekOrigin.Current:
                    pos = (int)_handles[hf] + dist;
                    break;
                //case SeekOrigin.End:
                default:
                    pos = _data.Length + dist;
                    break;
            }
            _handles[hf] = pos;
            return pos;
        }
        private IntPtr FnNotifyExtract(FDINOTIFICATIONTYPE fdint, FDINOTIFICATION fdin)
        {
            CabEntry entry;
            switch (fdint)
            {
                case FDINOTIFICATIONTYPE.COPY_FILE:
                    entry = new CabEntry(fdin);
                    entry._handle = new IntPtr(_handles.Count + 1);
                    _handles.Add(entry._handle, entry);
                    _currentEntryData = new MemoryStream();
                    return entry._handle;
                case FDINOTIFICATIONTYPE.CLOSE_FILE_INFO:
                    entry = (CabEntry)_handles[fdin.hf];
                    FnClose(fdin.hf);
                    OnEntryExtract(entry);
                    return new IntPtr(1);
                default:
                    return IntPtr.Zero;
            }
        }
        private enum FDINOTIFICATIONTYPE
        {
            CABINET_INFO = 0,
            PARTIAL_FILE = 1,
            COPY_FILE = 2,
            CLOSE_FILE_INFO = 3,
            NEXT_CABINET = 4,
            ENUMERATE = 5,
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct ERF
        {
            public int erfOper;
            public int erfType;
            public int fError;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal class FDINOTIFICATION
        {
            public int cb;
            public IntPtr psz1;
            public IntPtr psz2;
            public IntPtr psz3;
            public IntPtr pv;
            public IntPtr hf;
            public ushort date;
            public ushort time;
            public ushort attribs;
            public ushort setID;
            public ushort iCabinet;
            public ushort iFolder;
            public int fdie;
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr FNALLOC(int cb);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void FNFREE(IntPtr pv);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private delegate IntPtr FNOPEN(string pszFile, int oflag, int pmode);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FNREAD(IntPtr hf, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pv, int cb);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FNWRITE(IntPtr hf, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pv, int cb);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FNCLOSE(IntPtr hf);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FNSEEK(IntPtr hf, int dist, SeekOrigin seektype);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr FNFDINOTIFY(FDINOTIFICATIONTYPE fdint, FDINOTIFICATION pfdin);
        [DllImport("cabinet.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr FDICreate(IntPtr pfnalloc, IntPtr pfnfree, IntPtr pfnopen, IntPtr pfnread, IntPtr pfnwriter, IntPtr pfnclose, IntPtr pfnseek, int cpuType, IntPtr perf);
        [DllImport("cabinet.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr FDIDestroy(IntPtr hdfi);
        [DllImport("cabinet.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr FDICopy(IntPtr hdfi, string pszCabinet, string pszCabPath, int flags, IntPtr fnNotify, IntPtr fnDecrypt, IntPtr userData);
    }
    public sealed class CabEntry
    {
        internal IntPtr _handle;
        internal CabEntry(CabFile.FDINOTIFICATION fdin)
        {
            Name = Marshal.PtrToStringAnsi(fdin.psz1);
            Size = fdin.cb;
            LastWriteTime = new DateTime(1980 + GetMask(fdin.date, 9, 15), GetMask(fdin.date, 5, 8), GetMask(fdin.date, 0, 4),
                GetMask(fdin.time, 11, 15), GetMask(fdin.time, 5, 10), 2 * GetMask(fdin.time, 0, 4));
        }
        private static int GetMask(int value, byte startByte, byte endByte)
        {
            int final = 0;
            int v = 1;
            for (byte b = startByte; b <= endByte; b++)
            {
                if ((value & (1 << b)) != 0)
                {
                    final += v;
                }
                v = v * 2;
            }
            return final;
        }
        public string Name { get; private set; }
        public int Size { get; private set; }
        public DateTime LastWriteTime { get; private set; }
        public byte[] Data { get; internal set; }
    }
    public sealed class CabEntryExtractEventArgs : EventArgs
    {
        public CabEntryExtractEventArgs(CabEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");
            Entry = entry;
        }
        public CabEntry Entry { get; private set; }
    }
