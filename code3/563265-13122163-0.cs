    public class FooWriter : IDisposable {
        public StreamWriter Writer;
        public FooWriter()
        {
            Writer = new StreamWriter("MyFile.txt", false);
        }
        public void Write(string line)
        {
            // You do not need to guard the writer, because constructor sets it
            if(Writer==null)
                throw new NullReferenceException(Writer, "Writer"); // Guard Writer
            Writer.WriteLine(line);
        }
        public void Dispose()
        {
            Writer.Dispose();
        }
    }
