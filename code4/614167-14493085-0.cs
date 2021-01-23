    public class ThrowListener : TextWriterTraceListener
    {
        public override void Fail(string message)
        {
            throw new Exception(message);
        }
        
        public override void Fail(string message, string detailMessage)
        {
            throw new Exception(message);
        }
    }
