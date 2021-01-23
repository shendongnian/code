    public class MultiTextWriter: TextWriter
    {
        private List<TextWriter> _writers = new List<TextWriter>();
        public AddWriter(TextWriter writer)
        {
            _writers.Add(writer);
        }
        public override void Write(char ch)
        {
            foreach (var writer in _writers)
            {
                try
                {
                    _writer.Write(ch);
                }
                catch (ObjectDisposedException)
                {
                    // handle exception here
                }
                catch (IOException)
                {
                    // handle exception here
                }
            }
        }
    }
