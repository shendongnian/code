    public class FakeRootStreamReader : TextReader
    {
        private static readonly char[] _rootStart;
        private static readonly char[] _rootEnd;
        private readonly TextReader _innerReader;
        private int _charsRead;
        private bool _eof;
        static FakeRootStreamReader()
        {
            _rootStart = "<root>".ToCharArray();
            _rootEnd = "</root>".ToCharArray();
        }
        public FakeRootStreamReader(Stream stream)
        {
            _innerReader = new StreamReader(stream);
        }
        public FakeRootStreamReader(TextReader innerReader)
        {
            _innerReader = innerReader;
        }
        public override int Read(char[] buffer, int index, int count)
        {
            if (!_eof && _charsRead < _rootStart.Length)
            {
                // Prepend root element
                return ReadFake(_rootStart, buffer, index, count);
            }
            if (!_eof)
            {
                // Normal reading operation
                int charsRead = _innerReader.Read(buffer, index, count);
                if (charsRead > 0) return charsRead;
                // We've reached the end of the Stream
                _eof = true;
                _charsRead = 0;
            }
            // Append root element end tag at the end of the Stream
            return ReadFake(_rootEnd, buffer, index, count);
        }
        private int ReadFake(char[] source, char[] buffer, int offset, int count)
        {
            int length = Math.Min(source.Length - _charsRead, count);
            Array.Copy(source, _charsRead, buffer, offset, length);
            _charsRead += length;
            return length;
        }
    }
