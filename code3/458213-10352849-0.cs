    public class QueueStream : MemoryStream
    {
        long ReadPosition;
        long WritePosition;
        public QueueStream() : base() { }
        public override int Read(byte[] buffer, int offset, int count)
        {
            Position = ReadPosition;
            var temp = base.Read(buffer, offset, count);
            ReadPosition = Position;
            return temp;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            Position = WritePosition;
            
            base.Write(buffer, offset, count);
            WritePosition = Position;
        }
    }
