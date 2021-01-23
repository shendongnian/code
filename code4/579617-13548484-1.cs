    public class PeekingStreamReader : StreamReader
    {
        private Queue<string> _peeks;
        public PeekingStreamReader(Stream stream) : base(stream)
        {
            _peeks = new Queue<string>();   
        }
        public override string ReadLine()
        {
            if (_peeks.Count > 0)
            {
                var nextLine = _peeks.Dequeue();
                return nextLine;
            }
            return base.ReadLine();
        }
        public string PeekReadLine()
        {
            var nextLine = ReadLine();
            _peeks.Enqueue(nextLine);
            return nextLine;
        }
    }
