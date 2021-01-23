    public class PeekingStreamReader : StreamReader
    {
        private string _peek;
        private bool _hasPeek;
        public PeekingStreamReader(Stream stream) : base(stream)
        {
            
        }
        public override string ReadLine()
        {
            if (_hasPeek)
            {
                _hasPeek = false;
                return _peek;
            }
            _hasPeek = false;
            return base.ReadLine();
        }
        public string PeekReadLine()
        {
            if (_hasPeek) return _peek;
            _peek = ReadLine();
            _hasPeek = true;
            return _peek;
        }
    }
