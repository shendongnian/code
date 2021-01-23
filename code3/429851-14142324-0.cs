    protected void Application_Start(object sender, EventArgs e)
    {
        var writer = new LogWriter();
        Console.SetOut(writer);
    }
    public class LogWriter : TextWriter
    {
        public override void WriteLine(string value)
        {
            //do whatever with value
        }
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
