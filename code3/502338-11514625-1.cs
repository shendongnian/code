    public class MyWriter : IWriter
    {
        public void Write(string text)
        {
            // Do something to "write" text
        }
    }
    Logger.SetWriter(new MyWriter());
