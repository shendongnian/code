    class SlowWriter : TextWriter
    { // this opens and closs each time; slower, but doesn't lock the file
        private readonly string path;
        public SlowWriter(string path)
        {
            this.path = path;
        }
        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
        private TextWriter Append()
        {
            var finalPath = string.Format(path, DateTime.UtcNow.ToString("yyyyMMdd"));
            return File.AppendText(finalPath);
        }
        public override void Write(string value)
        {
            lock (this)
            {
                using (var file = Append())
                {
                    file.Write(value);
                }
            }
        }
        public override void Write(char[] buffer, int index, int count)
        {
            lock(this)
            {
                using (var file = Append())
                {
                    file.Write(buffer, index, count);
                }
            }
        }
        public override void Write(char[] buffer)
        {
            lock (this)
            {
                using (var file = Append())
                {
                    file.Write(buffer);
                }
            }
        }
    }
