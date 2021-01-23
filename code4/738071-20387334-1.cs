    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    public interface IStream
    {
        [PreserveSig]
        HResult Read([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [Out] byte[] pv, int cb, IntPtr pcbRead);
    
        [PreserveSig]
        HResult Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);
    
        [PreserveSig]
        HResult Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);
    
        [PreserveSig]
        HResult SetSize(long libNewSize);
    
        HResult CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);
    
        [PreserveSig]
        HResult Commit(int grfCommitFlags);
    
        [PreserveSig]
        HResult Revert();
    
        [PreserveSig]
        HResult LockRegion(long libOffset, long cb, int dwLockType);
    
        [PreserveSig]
        HResult UnlockRegion(long libOffset, long cb, int dwLockType);
    
        [PreserveSig]
        HResult Stat(out comtypes.STATSTG pstatstg, int grfStatFlag);
    
        [PreserveSig]
        HResult Clone(out IStream ppstm);
    }
        /// <summary>
        /// see http://msdn.microsoft.com/en-us/library/windows/desktop/ms752876(v=vs.85).aspx
        /// </summary>
        public class ComStream : Stream, IStream
        {
            private Stream _stream;
    
            public ComStream(Stream stream)
                : this(stream, true)
            {
            }
    
            internal ComStream(Stream stream, bool sync)
            {
                if (stream == null)
                    throw new ArgumentNullException("stream");
    
                if (sync)
                {
                    stream = Stream.Synchronized(stream);
                }
                _stream = stream;
            }
    
            HResult IStream.Clone(out IStream ppstm)
            {
                //ComStream newstream = new ComStream(_stream, false);
                //ppstm = newstream;
                ppstm = null;
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.Commit(int grfCommitFlags)
            {
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
            {
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.LockRegion(long libOffset, long cb, int dwLockType)
            {
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.Read(byte[] pv, int cb, IntPtr pcbRead)
            {
                if (!CanRead)
                    throw new InvalidOperationException("Stream not readable");
    
                int read = Read(pv, 0, cb);
                if (pcbRead != IntPtr.Zero)
                    Marshal.WriteInt64(pcbRead, read);
                return HResult.S_OK;
            }
    
            HResult IStream.Revert()
            {
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
            {
                SeekOrigin origin = (SeekOrigin)dwOrigin; //hope that the SeekOrigin enumeration won't change
                long pos = Seek(dlibMove, origin);
                if (plibNewPosition != IntPtr.Zero)
                    Marshal.WriteInt64(plibNewPosition, pos);
                return HResult.S_OK;
            }
    
            HResult IStream.SetSize(long libNewSize)
            {
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.Stat(out comtypes.STATSTG pstatstg, int grfStatFlag)
            {
                pstatstg = new comtypes.STATSTG();
                pstatstg.cbSize = Length;
                return HResult.S_OK;
            }
    
            HResult IStream.UnlockRegion(long libOffset, long cb, int dwLockType)
            {
                return HResult.E_NOTIMPL;
            }
    
            HResult IStream.Write(byte[] pv, int cb, IntPtr pcbWritten)
            {
                if (!CanWrite)
                    throw new InvalidOperationException("Stream is not writeable.");
    
                Write(pv, 0, cb);
                if (pcbWritten != null)
                    Marshal.WriteInt32(pcbWritten, cb);
                return HResult.S_OK;
            }
    
            public override bool CanRead
            {
                get { return _stream.CanRead; }
            }
    
            public override bool CanSeek
            {
                get { return _stream.CanSeek; }
            }
    
            public override bool CanWrite
            {
                get { return _stream.CanWrite; }
            }
    
            public override void Flush()
            {
                _stream.Flush();
            }
    
            public override long Length
            {
                get { return _stream.Length; }
            }
    
            public override long Position
            {
                get
                {
                    return _stream.Position;
                }
                set
                {
                    _stream.Position = value;
                }
            }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }
    
            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                _stream.Write(buffer, offset, count);
            }
    
            protected override void Dispose(bool disposing)
            {
                if (_stream != null)
                {
                    _stream.Dispose();
                    _stream = null;
                }
            }
        }
