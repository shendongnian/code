    public class ReadAllIntoMemoryFilter : MemoryStream
    {
        private readonly Stream _baseFilter;
        public ReadAllIntoMemoryFilter(Stream baseFilter)
        {
            _baseFilter = baseFilter;
        }
        public override void Close()
        {
            var bytes = GetBuffer();
            // do your work here
            _baseFilter.Write(bytes, 0, bytes.Length);
            _baseFilter.Close();
            base.Close();
        }
    }
