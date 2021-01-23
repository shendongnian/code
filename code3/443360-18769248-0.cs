    public delegate void PositionChanged(long position);
    public class ProgressTrackingFileStream: FileStream
    {
        public int AnnounceEveryBytes { get; set; }
        private long _lastPosition = 0;
        public event PositionChanged StreamPositionUpdated;
        // implementing other methods that the storage client may call, like ReadByte or Begin/EndRead is left as an exercise for the reader
        public override int Read(byte[] buffer, int offset, int count)
        {
            int i = base.Read(buffer, offset, count);
            MaybeAnnounce();
            return i;
        }
        private void MaybeAnnounce()
        {
            if (StreamPositionUpdated != null && (base.Position - _lastPosition) > AnnounceEveryBytes)
            {
                _lastPosition = base.Position;
                StreamPositionUpdated(_lastPosition);
            }
        }
        public ProgressTrackingFileStream(string path, FileMode fileMode) : base(path, fileMode) 
        {
            AnnounceEveryBytes = 32768;
        }
    }
