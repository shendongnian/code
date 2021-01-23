    public class Logger
    {
        // Make an object to use for locking
        private readonly object syncObj = new object();
        StremWriter sw;
        public Logger()
        {
            sw = new streamwriter(tempPath);
        }
        public void WriteLine(string textToOutput) 
        {
            lock(syncObj)
                sw.WriteLine(textToOutput);
        }
    }
