    public class FooWriter : IDisposable
    {
        public StreamWriter Writer { get; private set; }
    
        public FooWriter(string fileName)
        {
            Writer = new StreamWriter(fileName, false);
        }
    
        public void Write(string line)
        {                        
            Writer.WriteLine(line);
        }      
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposeManaged)
        {
            if (disposeManaged)
                Writer.Dispose();
        }
    }
