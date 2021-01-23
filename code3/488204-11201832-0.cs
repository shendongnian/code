    context.Log = new OutputWindowWriter();
    class OutputWindowWriter : System.IO.TextWriter
    {
        public override void Write(char[] buffer, int index, int count)
        {
            System.Diagnostics.Debug.Write(new String(buffer, index, count));
        }
        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }
        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }
    }
