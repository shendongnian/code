        public delegate void AppendConsoleText(string text);
        public AppendConsoleText appendConsoleTextDelegate;
        private void Form1_Load(object sender, EventArgs e)
        {
            appendConsoleTextDelegate = new AppendConsoleText(textBox1_AppendConsoleText);
            using (ProcessLauncher launcher = new ProcessLauncher(this))
            {
                launcher.Start();
            }
        }
        private void textBox1_AppendConsoleText(string text)
        {
            if (text != null)
            {
                textBox1.AppendText(text);
            }
        }
