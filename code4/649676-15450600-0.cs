    public class Csv : IReader, IWriter
    {
        protected Stream Stream = null;
        public string IsReader;
        private StreamWriter writer = null;
        private StreamReader reader = null;
        public Csv(string fileName)
        {
            Stream = new FileStream(fileName, FileMode.OpenOrCreate);
        }
        public StreamWriter SrWriter
        {
            get
            {
                if (reader == null)
                {
                    writer = new StreamWriter(Stream);
                }
                else
                {
                    throw new NullReferenceException("Current stream type is reader");
                }
                return writer;
            }
        }
        public StreamReader SrReader
        {
            get
            {
                if (writer == null)
                {
                    reader = new StreamReader(Stream);
                }
                else
                {
                    throw new NullReferenceException("Current stream type is writer");
                }
                return reader;
            }
        }
    }
        public interface IReader
        {
            StreamReader SrReader { get; }
        }
        public interface IWriter
        {
            StreamWriter SrWriter { get; }
        }
