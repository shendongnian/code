    public class BurnAfterReadingFileStream : Stream
        {
            private FileStream fs;
            public BurnAfterReadingFileStream(string path) { fs = System.IO.File.OpenRead(path); }
            
            public override bool CanRead { get { return fs.CanRead; } }
            public override bool CanSeek { get { return fs.CanRead; } }
            public override bool CanWrite { get { return fs.CanRead; } }
            public override void Flush() { fs.Flush(); }
            public override long Length { get { return fs.Length; } }
            public override long Position { get { return fs.Position; } set { fs.Position = value; } }
            public override int Read(byte[] buffer, int offset, int count) { return fs.Read(buffer, offset, count); }
            public override long Seek(long offset, SeekOrigin origin) { return fs.Seek(offset, origin); }
            public override void SetLength(long value) { fs.SetLength(value); }
            public override void Write(byte[] buffer, int offset, int count) { fs.Write(buffer, offset, count); }
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                fs.Close();
                if (System.IO.File.Exists(fs.Name))
                    try { System.IO.File.Delete(fs.Name); }
                    finally { }
            }
        }
