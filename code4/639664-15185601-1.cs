    public class DiskStream : Stream
    {
        public const int DEFAULT_SECTOR_SIZE = 512;
        private const int BUFFER_SIZE = 4096;
        private string diskID;
        private DiskInfo diskInfo;
        private FileAccess desiredAccess;
        private SafeFileHandle fileHandle;
        public DiskInfo DiskInfo
        {
            get { return this.diskInfo; }
        }
        public uint SectorSize
        {
            get { return this.diskInfo.BytesPerSector; }
        }
        public DiskStream(string diskID, FileAccess desiredAccess)
        {
            this.diskID = diskID;
            this.diskInfo = new DiskInfo(diskID);
            this.desiredAccess = desiredAccess;
            // if desiredAccess is Write or Read/Write
            //   find volumes on this disk
            //   lock the volumes using FSCTL_LOCK_VOLUME
            //     unlock the volumes on Close() or in destructor
            this.fileHandle = this.openFile(diskID, desiredAccess);
        }
        private SafeFileHandle openFile(string id, FileAccess desiredAccess)
        {
            uint access;
            switch (desiredAccess)
            {
                case FileAccess.Read:
                    access = DeviceIO.GENERIC_READ;
                    break;
                case FileAccess.Write:
                    access = DeviceIO.GENERIC_WRITE;
                    break;
                case FileAccess.ReadWrite:
                    access = DeviceIO.GENERIC_READ | DeviceIO.GENERIC_WRITE;
                    break;
                default:
                    access = DeviceIO.GENERIC_READ;
                    break;
            }
            SafeFileHandle ptr = DeviceIO.CreateFile(
                id,
                access,
                DeviceIO.FILE_SHARE_READ,
                IntPtr.Zero,
                DeviceIO.OPEN_EXISTING,
                DeviceIO.FILE_FLAG_NO_BUFFERING | DeviceIO.FILE_FLAG_WRITE_THROUGH,
                IntPtr.Zero);
            if (ptr.IsInvalid)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            return ptr;
        }
        public override bool CanRead
        {
            get
            {
                return (this.desiredAccess == FileAccess.Read || this.desiredAccess == FileAccess.ReadWrite) ? true : false;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return (this.desiredAccess == FileAccess.Write || this.desiredAccess == FileAccess.ReadWrite) ? true : false;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }
        public override long Length {
          get { return (long)this.Length; }
        }
        public ulong LengthU
        {
            get { return this.diskInfo.Size; }
        }
        public override long Position {
          get {
            return (long)PositionU;
          }
          set {
            PositionU = (ulong)value;
          }
        }
        public ulong PositionU
        {
            get
            {
                ulong n = 0;
                if (!DeviceIO.SetFilePointerEx(this.fileHandle, 0, out n, (uint)SeekOrigin.Current))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                return n;
            }
            set
            {
                if (value > (this.LengthU - 1))
                    throw new EndOfStreamException("Cannot set position beyond the end of the disk.");
                ulong n = 0;
                if (!DeviceIO.SetFilePointerEx(this.fileHandle, value, out n, (uint)SeekOrigin.Begin))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }
        
        public override void Flush()
        {
            // not required, since FILE_FLAG_WRITE_THROUGH and FILE_FLAG_NO_BUFFERING are used
            //if (!Unmanaged.FlushFileBuffers(this.fileHandle))
            //    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
        public override void Close()
        {
          if (this.fileHandle != null) {
            DeviceIO.CloseHandle(this.fileHandle);
            this.fileHandle.SetHandleAsInvalid();
            this.fileHandle = null;
          }
          base.Close();
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException("Setting the length is not supported with DiskStream objects.");
        }
        public override int Read(byte[] buffer, int offset, int count) {
          return (int)Read(buffer, (uint)offset, (uint)count);
        }
        public unsafe uint Read(byte[] buffer, uint offset, uint count)
        {
            uint n = 0;
            fixed (byte* p = buffer)
            {
                if (!DeviceIO.ReadFile(this.fileHandle, p + offset, count, &n, IntPtr.Zero))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            return n;
        }
        public override void Write(byte[] buffer, int offset, int count) {
          Write(buffer, (uint)offset, (uint)count);
        }
        public unsafe void Write(byte[] buffer, uint offset, uint count)
        {
            uint n = 0;
            fixed (byte* p = buffer)
            {
                if (!DeviceIO.WriteFile(this.fileHandle, p + offset, count, &n, IntPtr.Zero))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }
        public override long Seek(long offset, SeekOrigin origin) {
          return (long)SeekU((ulong)offset, origin);
        }
        public ulong SeekU(ulong offset, SeekOrigin origin)
        {
            ulong n = 0;
            if (!DeviceIO.SetFilePointerEx(this.fileHandle, offset, out n, (uint)origin))
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            return n;
        }
        public uint ReadSector(DiskSector sector)
        {
            return this.Read(sector.Data, 0, sector.SectorSize);
        }
        public void WriteSector(DiskSector sector)
        {
            this.Write(sector.Data, 0, sector.SectorSize);
        }
        public void SeekSector(DiskSector sector)
        {
            this.Seek(sector.Offset, SeekOrigin.Begin);
        }
    }
