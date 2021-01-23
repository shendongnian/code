    public class Foo
    {
        private Action<string> _writeLog;
        public Foo (Action<string> writeLog)
        {
            _writeLog = writeLog;
        }
        public void DoWork ()
        {
            _writeLog("Working...");
        }
    }
